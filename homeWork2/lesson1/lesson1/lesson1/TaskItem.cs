using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lesson1;
//
namespace lesson1;

public sealed class TaskItem
{
    public TaskItem()
    {
        _id = Sample.Counter;
        _name = $"CustomTask{ _id }";
        _ready = false;
        _lock = new Object();
    }

    private Action? _customTask;    
    private int _id = 0;
    private string _name;
    private object _lock;
    private bool _ready;

    public Action? CustomTask
    {
        get => _customTask;
        set => _customTask = value;
    }
    
    public int Id 
    {
        get => _id;
    }
    
    public string Name
    {
        get => _name;
    }

    public bool Ready
    {
        get => _ready;
        set => _ready = value;
    }

    public void Method0()
    {        
        if (_ready)
        {
            Console.WriteLine($"Method0 by {Thread.CurrentThread.Name}");
            if (Monitor.TryEnter(_lock))
            {
                Thread.Sleep(100);
                Console.WriteLine($"{Thread.CurrentThread.Name}: {Sample.IncrementWork()}");                                            
                Monitor.Exit(_lock);                
            }            
        }        
    }
}
