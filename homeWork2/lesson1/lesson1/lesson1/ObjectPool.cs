﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using lesson1;
//
namespace lesson1;

public sealed class ObjectPool<TPullItem> where TPullItem : PullItem, new()
{
    public ObjectPool(int threadCount)
    {
        _name = "CustomThreadPool";
        _threadSafetyDictionary = new ConcurrentDictionary<int, TPullItem>();        
        _threads = new Thread[threadCount];//кол-во доступных потоков по умолчанию
        _priority = ThreadPriority.Normal;
        _customTask = new();
        CreateThreads();
        int h = 6;
    }

    public object _lock = new object();    
    private readonly string _name;
    private ConcurrentDictionary<int, TPullItem> _threadSafetyDictionary;
    private Thread[] _threads;
    private ThreadPriority _priority;
    private Queue<Action?> _customTask;//<(Action<object?> CustomTask, object? Parameter)> _customTask;//= new()
    public int cnt = 0;

    public string Name => _name;

    public Thread[] Threads
    {
        get => _threads;
        set => _threads = value;
    }

    public ThreadPriority Priority
    {
        get => _priority;
        set => _priority = value;      
    }

    public Queue<Action?> CustomTask//<(Action<object?> Work, object? Parameter)> CustomTask
    {
        get => _customTask;
        set => _customTask = value;
    }

    public void AddTasks(Action? task)
    {
        _customTask.Enqueue(() => task());
        
    }

    public void CreateThreads()
    {
        var myobject = new object();
        for(int i = 0; i < _threads.Length; i++)
        {
            var thread = new Thread(new ParameterizedThreadStart(kkk));
            thread.Name = $"Thread{i + 1}";
            thread.Priority = _priority;
            thread.IsBackground = true;            
            //
            _threads[i] = thread;
            _threads[i].Start(i + 1);
        }
    }

    public void kkk(object? value)
    {
        if (value is not null)
        {
            bool acquiredLock = false; 
            if (Monitor.TryEnter(_lock))
            {
                Thread.Sleep(100);
                for (int i = 0; i < _threads.Length; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {cnt}");
                    cnt++;
                    
                }
                Monitor.Exit(_lock);
            }
                                                    
            //Thread.Sleep(3000);
            //Console.WriteLine(Thread.CurrentThread.Name);
            //Console.WriteLine($"{cnt} by {Thread.CurrentThread.Name}");
            
        }        
    }
    
    /*public TPullItem Create()
    {

        return new TPullItem();
    }

    public TPullItem Get()
    {
        if (_threadSafetyDictionary.Count > 0)
        {     
            foreach(var thread in _threadSafetyDictionary)
            {
                return _threadSafetyDictionary.FirstOrDefault().Value;
            }       
            //return _threadSafetyDictionary.FirstOrDefault().Value;
        }
        return Add(new TPullItem());
    }

    public void Release(TPullItem item)
    {
        if (item is null)
        {
            return;
        }

        item.Reset();
        _threadSafetyDictionary.TryAdd(Program1.IncrementCounter(), item);
    }

    public TPullItem Add(TPullItem item)
    {
        _threadSafetyDictionary.TryAdd(Program1.IncrementCounter(), item);
        return _threadSafetyDictionary[Program1.Counter];//(Program1.Counter, item);
    }*/

    /*public void HH(object? state)
    {
        var locker = _Locker;
        //
        lock (locker)
        {
            Thread.Sleep(3000);
            //
            if (value is not null)
            {
                if (_Size == Capacity)
                {
                    Resize();
                }

                _Data[_Size] = (T)value;
                _Size++;
                Console.WriteLine($"Добавлено { value } из { Thread.CurrentThread.Name } ");
            }
        }
    }*/
}
