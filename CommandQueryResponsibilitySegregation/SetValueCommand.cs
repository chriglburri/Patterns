using Autofac.Extras.DynamicProxy;
using Interception;

namespace CommandQueryResponsibilitySegregation
{
    [Intercept(typeof(Logger))]
    [Intercept(typeof(Authorization))]
    public class SetValueCommand : ISetValueCommand, IDisposable
    {

        public bool CanExecute()
        {
            Console.WriteLine("Can this command be executed.");
            return true;
        }

        public void Dispose()
        {
            // unregister events
            Console.WriteLine($"Dispose {nameof(SetValueCommand)}");
        }

        [Authorization(UserLevel.Expert)]
        public void SetValue(string value)
        {
            Console.WriteLine("Write the value to device.");
        }
    }
}
