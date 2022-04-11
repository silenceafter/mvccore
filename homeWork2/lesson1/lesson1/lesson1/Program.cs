using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using lesson1;

//namespace lesson1;

ObjectPool<ClassicPullItem> pool = new(5);
//pool.CustomTask.Enqueue(() => Program1.Method1());
//pool.CustomTask.Enqueue(() => Program1.Method2());
//pool.CustomTask.Enqueue(() => Program1.Method3());
//Console.Pau
Console.ReadLine();
int y = 6;

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

    public static Action? Method1()
    {
        Console.WriteLine("Method1");
        return null;
    }

    public static Action? Method2()
    {
        Console.WriteLine("Method2");
        return null;
    }

    public static Action? Method3()
    {
        Console.WriteLine("Method3");
        return null;
    }    
}










