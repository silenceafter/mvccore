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
    private Thread _j;
    public Thread J
    {
        get => _j;
    }

    public ClassicPullItem()
    {
        var t = new Thread(new ParameterizedThreadStart(GG));
        t.Name = "Thread1";
        t.Start(0);
        Id = Program1.IncrementCounter();
        Name = "";


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
        var locker = _j;
        //
        lock (locker)
        {
            Thread.Sleep(3000);
            //
            if (state is not null)
            {
                
            }
        }
    }
}
