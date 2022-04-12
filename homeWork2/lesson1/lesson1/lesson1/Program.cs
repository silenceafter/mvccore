using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using lesson1;

ObjectPool pool = new(5);
//Action? method1 = Sample.Method1;

//объекты задач, которые содержат делегат
for(int i = 0; i < 7; i++)
{
    TaskItem task_current = new();
    task_current.CustomTask = task_current.Method0;
    pool.AddTasks(task_current, true);
}
//
Console.ReadLine();

static class Sample
{
    private static int _counter = 0;
    private static int _workCounter = 0;

    public static int Counter
    {
        get => _counter;
        set => _counter = value;
    }

    public static int WorkCounter
    {
        get => _workCounter;
        set => _workCounter = value;
    }

    public static int IncrementCounter()
    {
        return ++_counter;
    }

    public static int IncrementWork()
    {
        return ++_workCounter;
    }  
}










