using Castle.DynamicProxy;

namespace Interception
{
    public class Logger : IInterceptor
    {
        public Logger()
        {
            // Inject dependencies to logging framework. e.g. nLog, log4net etc
            Color = ConsoleColor.Yellow;
            DefaultColor = Console.ForegroundColor;
        }

        private ConsoleColor Color { get;  }
        private ConsoleColor DefaultColor { get; }

        public void Intercept(IInvocation invocation)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("Calling method {0} with parameters {1}... ",
                invocation.Method.Name,
                string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));
            Console.ForegroundColor = DefaultColor;

            invocation.Proceed();

            Console.ForegroundColor = Color;
            Console.WriteLine("Done: result was {0}.", invocation.ReturnValue);
            Console.ForegroundColor = DefaultColor;
        }
    }
}