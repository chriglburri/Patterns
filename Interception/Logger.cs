using Castle.DynamicProxy;
using CmdLineTools;

namespace Interception
{
    public class Logger : IInterceptor
    {
        private ConsoleColor Color { get; }= ConsoleColor.Yellow;


        public Logger()
        {
            // Inject dependencies to logging framework. e.g. nLog, log4net etc
        }

        public void Intercept(IInvocation invocation)
        {
            using (new ColorSwitcher(Color)) { 
            Console.WriteLine("Calling method {0} with parameters {1}... ",
                invocation.Method.Name,
                string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));
            }

            invocation.Proceed();

            using (new ColorSwitcher(Color))
            {
                Console.WriteLine("Done: result was {0}.", invocation.ReturnValue);
            }
        }
    }
}