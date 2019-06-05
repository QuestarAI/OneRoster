using System.Linq;
using System.Reflection;

namespace Questar.OneRoster.Filtering
{
    internal static class FilterInfo
    {
        internal static MethodInfo Any { get; } = GetEnumerableMethod(nameof(Enumerable.Any), 2);

        internal static MethodInfo All { get; } = GetEnumerableMethod(nameof(Enumerable.All), 2);

        internal static MethodInfo Contains { get; } = GetEnumerableMethod(nameof(Enumerable.Contains), 2);

        private static MethodInfo GetEnumerableMethod(string name, int arity)
        {
            return typeof(Enumerable)
                .GetTypeInfo()
                .GetMethods()
                .Single(method => method.Name == name && method.GetParameters().Length == arity);
        }
    }
}