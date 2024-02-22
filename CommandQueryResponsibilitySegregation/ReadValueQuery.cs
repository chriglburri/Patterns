using Autofac.Extras.DynamicProxy;
using Interception;

namespace CommandQueryResponsibilitySegregation
{
    [Intercept(typeof(Logger))]
    public class ReadValueQuery : IReadValueQuery, IDisposable
    {
        public void Dispose()
        {
            // unregister events
            Console.WriteLine($"Dispose {nameof(SetValueCommand)}");
        }

        public string GetValue()
        {
            Console.WriteLine("Read the value from device.");
            return "the value!";
        }
    }
}