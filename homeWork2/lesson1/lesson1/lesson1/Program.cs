using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using lesson1;

//namespace lesson1;

ObjectPool<ClassicPullItem> pool = new(5);
ClassicPullItem m1 = new ClassicPullItem();
pool.AddTasks(m1);
/*Action? name1 = Program1.Method1;
Action? name2 = Program1.Method2;
pool.AddTasks(name1);
pool.AddTasks(name2);
pool.AddTasks(Program1.Method3);*/
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

    public static void Method1()
    {
        Console.WriteLine($"Method1 by {Thread.CurrentThread.Name}");
        //return null;
    }

    public static void Method2()
    {
        Console.WriteLine($"Method2 by {Thread.CurrentThread.Name}");
        //return null;
    }

    public static void Method3()
    {
        Console.WriteLine($"Method3 by {Thread.CurrentThread.Name}");
        //return null;
    }    
}










