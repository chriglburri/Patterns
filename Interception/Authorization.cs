using Castle.DynamicProxy;

namespace Interception
{
    // TODO CONTINUE HERE. NOT USED YET
    public class Authorization : IInterceptor
    {
        public Authorization()
        {
            // inject a user level provider here
            Level = UserLevel.Expert;
        }

        public UserLevel Level { get; private set; }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.CustomAttributes.Any(x => x.AttributeType == typeof(AdvancedLevelAttribute)) 
                && Level >= UserLevel.Advanced)
            {
                Console.WriteLine("it's OK");
                invocation.Proceed();
                return;
            }
            if (invocation.Method.CustomAttributes.Any(x => x.AttributeType == typeof(ExpertLevelAttribute)) 
                && Level >= UserLevel.Expert)
            {

                Console.WriteLine("it's OK");
                invocation.Proceed();
                return;
            }
        }
    }

    public class AdvancedLevelAttribute : Attribute
    {
    }
    public class ExpertLevelAttribute : Attribute
    {
    }
    public enum UserLevel
    {
        Standard,
        Advanced,
        Expert
    }
}
