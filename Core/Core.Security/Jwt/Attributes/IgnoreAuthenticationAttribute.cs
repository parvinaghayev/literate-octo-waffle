namespace Core.Security.Jwt.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class IgnoreAuthenticationAttribute : Attribute
{
}