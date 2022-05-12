using Autofac;
using Autofac.Core;
using homeWork6.Interfaces;
using Microsoft.Extensions.Logging;
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

                var scanner = scope.Resolve<IScannerDevice>();
                //
                if (scanner is not null)
                {
                    var loggerFactory = scope.Resolve<ILoggerFactory>();
                    //
                    if (loggerFactory is null) throw new Exception("loggerFactory is not create");
                    //
                    var logger = loggerFactory.CreateLogger<ScannerContext>();
                    var scannerContext = scope.Resolve<ScannerContext>(
                        new NamedParameter("device", scanner),
                        new NamedParameter("logger", logger));
                    var device = scannerContext.Device;
                    //
                    if (device is not null)
                    {
                        //сканировать и передать байты
                        //1
                        byte[] cpu_one_array, ram_one_array;
                        cpu_one_array = device.Scan(cpu_one);
                        ram_one_array = device.Scan(ram_one);

                        //2
                        byte[] cpu_two_array, ram_two_array;
                        cpu_two_array = device.Scan(cpu_two);
                        ram_two_array = device.Scan(ram_two);

                        //3
                        byte[] cpu_three_array, ram_three_array;
                        cpu_three_array = device.Scan(cpu_three);
                        ram_three_array = device.Scan(ram_three);

                        //json
                        var jsonStrategy = scope.Resolve<JsonScanOutputStrategy>();
                        scannerContext.CurrentStrategy = jsonStrategy;
                        //
                        scannerContext.Execute(cpu_one_array);
                        scannerContext.Execute(cpu_two_array);
                        scannerContext.Execute(cpu_three_array);

                        scannerContext.Execute(ram_one_array);
                        scannerContext.Execute(ram_two_array);
                        scannerContext.Execute(ram_three_array);

                        //xml
                        var xmlStrategy = scope.Resolve<XmlScanOutputStrategy>();
                        scannerContext.CurrentStrategy = xmlStrategy;
                        //
                        scannerContext.Execute(cpu_one_array);
                        scannerContext.Execute(cpu_two_array);
                        scannerContext.Execute(cpu_three_array);

                        scannerContext.Execute(ram_one_array);
                        scannerContext.Execute(ram_two_array);
                        scannerContext.Execute(ram_three_array);
                    }                                       
                }
            }
        }
    }
}
