using Autofac.Core;
using Autofac;
using CommandQueryResponsibilitySegregation;
using Factory;

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
                Console.WriteLine("--------Read Vaule Demo:-------");
                var query = scope.Resolve<IReadValueQuery>()!;
                var value = query.GetValue();

                Console.WriteLine("--------Write Vaule Demo:-------");
                var command = scope.Resolve<ISetValueCommand>()!;
                if (command.CanExecute())
                {
                    value = "New value";
                    command.SetValue(value);
                }

                Console.WriteLine("--------Factory Demo:-------");
                var items = scope.Resolve<IItems>()!;
                items.Create(PromptForItems());


            }
            Console.ReadKey();
        }

        private static int PromptForItems()
        {
            Console.Write("Creating N items. N=...?");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}