namespace Questar.OneRoster.Query
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal class ReflectionCache<T>
    {
        // ReSharper disable StaticMemberInGenericType

        internal static readonly Type Type = typeof(T);

        internal static readonly Dictionary<string, Type> PropertyTypesByName = Type
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .ToDictionary(p => p.Name, p => p.PropertyType, StringComparer.OrdinalIgnoreCase);

        internal static readonly IList<string> PropertyNames = PropertyTypesByName
            .Select(pair => pair.Key)
            .ToList();

        // ReSharper enable StaticMemberInGenericType
    }
}