using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using lesson1;

//namespace lesson1;

ObjectPool<ClassicPullItem> pool = new();
var lockObjectOne = new object();

ClassicPullItem item = pool.Get();
item.Id = 100;
item.Name = "Just4Fun";
pool.Release(item);

ClassicPullItem itemSecond = pool.Get();
itemSecond.Id = 

static class Program1
{
    private static int _counter = 0;

    public static int Counter
    {
        get => _counter;
        set => _counter = value;
    }

    public static int IncrementCounter()
    {
        return ++_counter;
    }
}










