﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork6.Interfaces
{
    public interface IScannerDevice
    {
        byte[] Scan(object data);
    }
}
