using Autofac.Core;
using Autofac;
using CommandQueryResponsibilitySegregation;

namespace Demo
{

    public class Program
    {

        private static void Main(string[] args)
        {
            var config = new Configurator();
            var container = config.Container;

            using (var scope = container.BeginLifetimeScope())
            {
                var query = scope.Resolve<IReadValueQuery>();
                var value = query.GetValue();
                var command = scope.Resolve<ISetValueCommand>();
                if (command.CanExecute())
                {
                    value = "New value";
                    command.SetValue(value);
                }
            }
            Console.ReadKey();
        }
    }
}