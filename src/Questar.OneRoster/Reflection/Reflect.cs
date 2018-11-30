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
            => TypeDescriptor.GetConverter(type);

        public static TypeConverter GetConverter(this PropertyInfo property)
            => TypeDescriptor.GetProperties(property.DeclaringType).Find(property.Name, false).Converter;
    }

    public static class Reflect<T>
    {
        // ReSharper disable StaticMemberInGenericType

        public static readonly Type Type = typeof(T);

        private static readonly Dictionary<string, Type> Properties =
            Type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(property => property.Name, property => property.PropertyType, StringComparer.OrdinalIgnoreCase);

        static Reflect()
        {
            PropertyTypesByName = Properties;
            PropertyNames = Properties.Keys;
        }

        public static IReadOnlyDictionary<string, Type> PropertyTypesByName { get; }

        public static IReadOnlyCollection<string> PropertyNames { get; }

        // ReSharper enable StaticMemberInGenericType
    }
}