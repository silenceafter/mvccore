using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using lesson1;
//
namespace lesson1;

public class ObjectPool
{
    public ObjectPool(int threadCount)
    {
        _name = "CustomThreadPool";      
        _threads = new Thread[threadCount];//кол-во доступных потоков по умолчанию
        _handle = new AutoResetEvent(true);
        _priority = ThreadPriority.Normal;
        _customTask = new();
        CreateThreads();
    }
   
    private readonly string _name;
    private Thread[] _threads;
    private EventWaitHandle _handle;
    private ThreadPriority _priority;
    private Queue<TaskItem?> _customTask;

    public string Name => _name;

    public Thread[] Threads
    {
        get => _threads;
        set => _threads = value;
    }

    public EventWaitHandle Handle
    {
        get => _handle;
        set => _handle = value;
    }
    public ThreadPriority Priority
    {
        get => _priority;
        set => _priority = value;      
    }

    public Queue<TaskItem?> CustomTask
    {
        get => _customTask;
        set => _customTask = value;
    }

    public void AddTasks(TaskItem? taskObject, bool activate = false)
    {
        if (taskObject != null) 
        {
            if (activate) 
            {
                taskObject.Ready = true; 
            }
            //
            _customTask.Enqueue(taskObject);
            //Console.WriteLine("Метод AddTasks()");
            ManageTasks();            
        }
    }

    public void ManageTasks() 
    {
        //Console.WriteLine($"Метод ManageTasks: {_customTask.Count}");
        if (_customTask.Count > 0) 
        {
            StartWorking();
        }
    }

    public void CreateThreads()
    {
        var myobject = new object();
        for(int i = 0; i < _threads.Length; i++)
        {
            var thread = new Thread(new ParameterizedThreadStart(WorkingTask));
            thread.Name = $"Thread{i + 1}";
            thread.Priority = _priority;
            thread.IsBackground = true;            
            //
            _threads[i] = thread;
            _threads[i].Start(i + 1);
        }
    }

    public void WorkingTask(object? value)
    {
        //параметр value пока не задействован
        //Console.WriteLine($"Метод WorkingTask by {Thread.CurrentThread.Name}");
        while(true)
        {
            _handle.WaitOne();
            if (_customTask.Count > 0)
            {
                
                var taskObject = _customTask.Dequeue();
                if (taskObject != null)
                {
                    var task = taskObject.CustomTask;
                    if (task != null)
                    {
                        task();
                    }                    
                }            
            }
        }       
    }

    public void StartWorking()
    {
        _handle.Set();
    }
}
