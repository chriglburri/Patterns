using Autofac;
using Autofac.Extras.DynamicProxy;
using CommandQueryResponsibilitySegregation;
using Factory;
using Interception;

namespace Demo
{
    public class Configurator
    {
        public IContainer Container { get; set; }

        public Configurator()
        {
            Container = AutofacConfig();
        }
        private IContainer AutofacConfig()
        {
            var builder = new ContainerBuilder();
            // Interceptor
            builder.RegisterType<Logger>();
            builder.RegisterType<Authorization>();

            // CommandQueryResponsibilitySegregation
            builder.RegisterType<SetValueCommand>()
                .As<ISetValueCommand>()
                .EnableInterfaceInterceptors();

            builder.RegisterType<ReadValueQuery>()
                .As<IReadValueQuery>()
                .EnableInterfaceInterceptors();

            // Factory in .ctor is automatically registered (hence the name "AutoFac")
            builder.RegisterType<Item>();
            builder.RegisterType<Items>().As<IItems>();
            

            return builder.Build();
        }
    }
}