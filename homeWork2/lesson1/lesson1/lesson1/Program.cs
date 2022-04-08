using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using lesson1;

//namespace lesson1;

ObjectPool<ClassicPullItem> pool = new();
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
}










