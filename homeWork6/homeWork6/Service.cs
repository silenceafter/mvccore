using homeWork6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork6
{
    public class Service : IService
    {
        public void WriteInformation(string message)
        {
            Console.WriteLine(message);
        }
    }
}
