using Autofac;
using Autofac.Extras.DynamicProxy;
using CommandQueryResponsibilitySegregation;
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
            builder.RegisterType<Logger>();

            builder.RegisterType<SetValueCommand>()
                .As<ISetValueCommand>()
                .EnableInterfaceInterceptors();

            builder.RegisterType<ReadValueQuery>()
                .As<IReadValueQuery>()
                .EnableInterfaceInterceptors();

            return builder.Build();
        }
    }
}