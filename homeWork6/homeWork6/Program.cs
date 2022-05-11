using Autofac;
using Autofac.Core;
using homeWork6.Interfaces;
using System;
using System.Collections.Generic;

namespace homeWork6
{
    class Program
    {        
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                //1
                var cpu_one = scope.Resolve<ICpuData>(
                    new NamedParameter("percent", 25),
                    new NamedParameter("threads", 4),
                    new NamedParameter("error", false));

                var ram_one = scope.Resolve<IRamData>(
                    new NamedParameter("freeMem", 2048),
                    new NamedParameter("totalMem", 4096),
                    new NamedParameter("error", false));

                //2
                var cpu_two = scope.Resolve<ICpuData>(
                    new NamedParameter("percent", 50),
                    new NamedParameter("threads", 4),
                    new NamedParameter("error", false));

                var ram_two = scope.Resolve<IRamData>(
                    new NamedParameter("freeMem", 1024),
                    new NamedParameter("totalMem", 4096),
                    new NamedParameter("error", false));

                //3
                var cpu_three = scope.Resolve<ICpuData>(
                    new NamedParameter("percent", 75),
                    new NamedParameter("threads", 4),
                    new NamedParameter("error", false));

                var ram_three = scope.Resolve<IRamData>(
                    new NamedParameter("freeMem", 3035),
                    new NamedParameter("totalMem", 4096),
                    new NamedParameter("error", false));

                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
