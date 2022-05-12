using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace homeWork6
{
    public static class Helper
    {
        public static byte[] GetBinaryArray(object current)
        {
            return JsonSerializer.SerializeToUtf8Bytes(current);
        }
    }
}
