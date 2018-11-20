namespace Questar.OneRoster.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    public static class Reflect
    {
        public static TypeConverter GetConverter(this Type type)
        {
            return TypeDescriptor.GetConverter(type);
        }

        public static TypeConverter GetConverter(this PropertyInfo property)
        {
            return TypeDescriptor.GetProperties(property.DeclaringType).Find(property.Name, false).Converter;
        }
    }

    public static class Reflect<T>
    {
        // ReSharper disable StaticMemberInGenericType

        public static readonly Type Type = typeof(T);

        public static readonly IReadOnlyDictionary<string, Type> PropertyTypesByName =
            Type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(property => property.Name, property => property.PropertyType, StringComparer.OrdinalIgnoreCase);

        public static IEnumerable<string> PropertyNames => PropertyTypesByName.Keys;

        // ReSharper enable StaticMemberInGenericType
    }
}