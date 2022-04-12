using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lesson1;
//
namespace lesson1;

public sealed class ClassicPullItem : PullItem
{
    public ClassicPullItem()
    {
        _name = $"CustomTask{ Program1.Counter }";
        _ready = false;
        _lock = new Object();
        /*_item = new Thread(new ParameterizedThreadStart(GG));
        _item.Name = $"Thread{ Program1.Counter }";
        //_item.Start(0);
        _id = Program1.Counter;//Program1.IncrementCounter();
        _name = _item.Name;*/
    }

    //private Thread _item;
    private Action? _customTask;
    private object _lock;
    private bool _ready;
    private int _id = 0;
    private string _name = "";

    public Action? CustomTask
    {
        get => _customTask;
        set => _customTask = value;
    }

    public bool Ready
    {
        get => _ready;
        set => _ready = value;
    }

    /*public Thread Item
    {
        get => _item;
    }*/
    
    public int Id 
    {
        get => _id;
        set => _id = value;
    }
    
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public override void Reset()
    {
        _id = 0;
        _name = string.Empty;
    }

    public void Method0()
    {
        if (_ready) 
        {
            Console.WriteLine("Method0");
        }        
    }

    /*public void GG(object? state)
    {
        Thread.Sleep(3000);
        /*var locker = _j;
        //
        lock (locker)
        {
            Thread.Sleep(3000);
            //
            if (state is not null)
            {
                
            }
        }*/
    //}
}
