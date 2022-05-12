using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork6.Interfaces
{
    public interface IScanOutputStrategy
    {
        void Save(string filename, byte[] data);
    }
}
