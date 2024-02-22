using Autofac.Extras.DynamicProxy;
using Interception;

namespace CommandQueryResponsibilitySegregation
{
    [Intercept(typeof(Logger))]
    public class SetValueCommand : ISetValueCommand, IDisposable
    {
        public bool CanExecute()
        {
            // Check business logic if command can be executes.
            // Do not check user authorization
            Console.WriteLine("Can this command be executed.");
            return true;
        }

        public void Dispose()
        {
            // unregister events
            Console.WriteLine($"Dispose {nameof(SetValueCommand)}");
        }

        public void SetValue(string value)
        {
            Console.WriteLine("Write the value to device.");
        }
    }
}
