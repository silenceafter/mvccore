using Autofac;
using homeWork6.Interfaces;
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
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<Service>().As<IService>();
            //
            builder.RegisterType<CustomCpu>().As<ICpuData>();
            builder.RegisterType<CustomRam>().As<IRamData>();
            return builder.Build();
        }
    }
}
