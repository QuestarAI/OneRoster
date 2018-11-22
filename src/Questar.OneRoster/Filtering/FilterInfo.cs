namespace Questar.OneRoster.Filtering
{
    using System.Linq;
    using System.Reflection;

    internal static class FilterInfo
    {
        internal static MethodInfo Any { get; } = GetEnumerableMethod(nameof(Enumerable.Any), 2);

        internal static MethodInfo All { get; } = GetEnumerableMethod(nameof(Enumerable.All), 2);

        internal static MethodInfo Contains { get; } = GetEnumerableMethod(nameof(Enumerable.Contains), 2);

        private static MethodInfo GetEnumerableMethod(string name, int arity)
            => typeof(Enumerable)
                .GetMethods()
                .Single(method => method.Name == name && method.GetParameters().Length == arity);
    }
}