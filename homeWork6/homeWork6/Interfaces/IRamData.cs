using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork6.Interfaces
{
    public interface IRamData
    {
        int FreeMem { get; }
        int TotalMem { get; }
        bool Error { get; }
    }
}
