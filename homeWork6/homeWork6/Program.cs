using Autofac;
using homeWork6.Interfaces;
using System;

namespace homeWork6
{
    static class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CustomCpu>().As<ICpuData>();
            builder.RegisterType<CustomRam>().As<IRamData>();


            builder.RegisterType<Application>();
            return builder.Build();
        }

        public static void Main()
        {
            CompositionRoot().Resolve<Application>().Run();
        }
    }
}
