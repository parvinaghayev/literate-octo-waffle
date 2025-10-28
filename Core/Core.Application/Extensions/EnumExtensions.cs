using Core.Domain.Enums;
using System.ComponentModel;
using System.Reflection;

namespace Core.Application.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes =
            fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        if (attributes != null && attributes.Any())
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }

    public static T GetValue<T>(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        ValueAttribute<T>[] attributes =
            fi.GetCustomAttributes(typeof(ValueAttribute<T>), false) as ValueAttribute<T>[];

        return attributes.First().Value;
    }

    public static T[] GetValues<T>(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        ValueAttribute<T>[] attributes =
            fi.GetCustomAttributes(typeof(ValueAttribute<T>), false) as ValueAttribute<T>[];

        return attributes.First().Values;
    }

    public static int ToInt(this Enum value) => Convert.ToInt32(value);
}