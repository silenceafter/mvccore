using homeWork6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork6
{
    public class Application : IApplication
    {
        private readonly IService _service;
        public Application(IService service)
        {
            _service = service;
        }

        public void Run()
        {
            _service.WriteInformation("Injected!");
        }
    }
}
