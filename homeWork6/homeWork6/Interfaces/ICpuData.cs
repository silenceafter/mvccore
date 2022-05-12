using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork6.Interfaces
{
    public interface ICpuData
    {
        int Percent { get; }
        int Threads { get; }
        bool Error { get; }
    }
}
