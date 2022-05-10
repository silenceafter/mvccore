using homeWork6.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork6
{
    public class CustomScannerDevice : IScannerDevice
    {
        private Stream? _data;

        public Stream? Data
        {
            get => _data;
            set => _data = value;
        }

        public byte[] Scan(object data)
        {
            if (data is null) throw new NullReferenceException();
            return Helper.GetBinaryArray(data);
        }
    }
}
