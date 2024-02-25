using Castle.DynamicProxy;
using CmdLineTools;

namespace Interception
{
    public class Authorization : IInterceptor
    {
        public UserLevel Level { get; private set; } = UserLevel.Standard;
        private ConsoleColor Color { get; } = ConsoleColor.Red;

        public Authorization()
        {
            // inject a user level provider here
            Level = UserLevel.Expert;
        }

        public void Intercept(IInvocation invocation)
        {
            AuthorizationAttribute? authAtt =
            invocation.GetConcreteMethodInvocationTarget()
                .GetCustomAttributes(typeof(AuthorizationAttribute), true)
                .FirstOrDefault() as AuthorizationAttribute;
            if (authAtt is null)
            {
                using(new ColorSwitcher(Color)) { 
                    Console.WriteLine("No authorization attribute defined");
                }
                invocation.Proceed();
                return;
            }

            if (Level >= authAtt.Level)
            {
                using (new ColorSwitcher(Color))
                {
                    Console.WriteLine($"authorized with level: {Level}");
                }
                invocation.Proceed();
                return;
            }

            using (new ColorSwitcher(Color))
            {
                Console.WriteLine($"not authorized with level: {Level}");
            }
            return;
        }
    }
}