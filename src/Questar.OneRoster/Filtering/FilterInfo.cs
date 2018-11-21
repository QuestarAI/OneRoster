namespace Questar.OneRoster.Filtering
{
    using System.Linq;
    using System.Reflection;

    internal static class FilterInfo
    {
        internal static readonly MethodInfo Any
            = typeof(Enumerable)
                .GetMethods()
                .Single(method => method.Name == nameof(Enumerable.Any) && method.GetParameters().Length == 2);

        internal static readonly MethodInfo All
            = typeof(Enumerable)
                .GetMethods()
                .Single(method => method.Name == nameof(Enumerable.All) && method.GetParameters().Length == 2);

        internal static readonly MethodInfo Contains
            = typeof(Enumerable)
                .GetMethods()
                .Single(method => method.Name == nameof(Enumerable.Contains) && method.GetParameters().Length == 2);
    }
}