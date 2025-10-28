namespace Core.Domain.Enums
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ValueAttribute<T> : Attribute
    {
        public readonly T Value;
        public readonly T[] Values;

        public ValueAttribute(T value)
        {
            Value = value;
        }

        public ValueAttribute(params T[] values)
        {
            Values = values;
        }
    }
}