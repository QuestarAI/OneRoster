namespace Questar.OneRoster.Query
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ReflectionCache<T>
    {
        // ReSharper disable StaticMemberInGenericType

        public static readonly Type Type = typeof(T);

        public static readonly Dictionary<string, Type> PropertyTypesByName = Type
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .ToDictionary(p => p.Name, p => p.PropertyType, StringComparer.OrdinalIgnoreCase);

        public static readonly IList<string> PropertyNames = PropertyTypesByName
            .Select(pair => pair.Key)
            .ToList();

        // ReSharper enable StaticMemberInGenericType
    }
}