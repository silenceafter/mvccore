using Autofac;
using homeWork6.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork6
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            //logger      
            builder.RegisterInstance(LoggerFactory.Create(config => config
                .AddConsole()
                .SetMinimumLevel(LogLevel.Trace)
            ));
            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>));
            //
            builder.RegisterType<CustomCpu>().As<ICpuData>();
            builder.RegisterType<CustomRam>().As<IRamData>();
            builder.RegisterType<CustomScannerDevice>().As<IScannerDevice>();
            builder.RegisterType<ScannerContext>().AsSelf();
            builder.RegisterType<JsonScanOutputStrategy>().As<IScanOutputStrategy>().AsSelf();
            builder.RegisterType<XmlScanOutputStrategy>().As<IScanOutputStrategy>().AsSelf();
            return builder.Build();
        }
    }
}
