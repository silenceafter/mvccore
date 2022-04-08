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

public sealed class ObjectPool<TPullItem> where TPullItem : PullItem, new()
{
    public ObjectPool(int treadCount)
    {
        _threadSafetyDictionary = new ConcurrentDictionary<int, TPullItem>();        
        _threads = new Thread[treadCount];//кол-во доступных потоков по умолчанию
        _customTask = new();
    }

    private ConcurrentDictionary<int, TPullItem> _threadSafetyDictionary;
    private Thread[] _threads;
    private Queue<(Action<object?> Work, object? Parameter)> _customTask;//= new()

    public Thread[] Threads
    {
        get => _threads;
        set => _threads = value;
    }

    public Queue<(Action<object?> Work, object? Parameter)> CustomTask
    {
        get => _customTask;
        set => _customTask = value;
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
