namespace Interception
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizationAttribute : Attribute
    {
        public UserLevel Level { get; }

        public AuthorizationAttribute(UserLevel level)
        {
            Level = level;
        }
    }
}