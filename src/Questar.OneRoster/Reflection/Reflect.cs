namespace Questar.OneRoster.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    public static class Reflect
    {
        public static Type GetItemType(this Type type)
        {
            var collection = type.Name != typeof(ICollection<>).Name
                ? type.GetInterface(typeof(ICollection<>).Name)
                : type;
            return collection.GetGenericArguments().Single();
        }

        public static TypeConverter GetConverter(this Type type)
        {
            return TypeDescriptor.GetConverter(type);
        }

        public static TypeConverter GetConverter(this PropertyInfo property)
        {
            return property.GetDescriptor().Converter;
        }

        public static PropertyDescriptor GetDescriptor(this PropertyInfo property)
        {
            return TypeDescriptor.GetProperties(property.DeclaringType).Find(property.Name, false);
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