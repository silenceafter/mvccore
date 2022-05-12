using homeWork6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork6
{
    public class CustomRam : IRamData
    {
        public CustomRam(int freeMem, int totalMem, bool error)
        {
            _freeMem = freeMem;
            _totalMem = totalMem;
            _error = error;
        }

        private int _freeMem;
        private int _totalMem;
        private bool _error;

        public int FreeMem
        {
            get => _freeMem;
        }

        public int TotalMem
        {
            get => _totalMem;
        }

        public bool Error
        {
            get => _error;
        }
    }
}
