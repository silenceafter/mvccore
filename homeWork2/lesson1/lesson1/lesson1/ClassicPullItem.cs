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
    private Thread _item;
    public Thread Item
    {
        get => _item;
    }

    public ClassicPullItem()
    {
        _item = new Thread(new ParameterizedThreadStart(GG));
        _item.Name = $"Thread{ Program1.Counter }";
        //_item.Start(0);
        Id = Program1.Counter;//Program1.IncrementCounter();
        Name = _item.Name;
    }

    public int Id { get; set; }
    public string Name { get; set; }



    public override void Reset()
    {
        Id = 0;
        Name = string.Empty;
    }

    public void GG(object? state)
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
    }

    public int GetId()
    {
        return this.Id;
    }
}
