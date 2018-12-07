namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;

    internal static class DynamicQueryable
    {
        public static IQueryable<dynamic> DynamicSelect<T>(this IQueryable<T> queryable, IEnumerable<string> paths)
        {
            var source = typeof(T);
            var fields = paths.ToDictionary(member => member, member =>
            {
                var property = source.GetProperty(member, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                    throw new InvalidOperationException($"Could not find property '{member}' on type '{source.Name}'.");
                return property.PropertyType;
            });

            // TODO get full path
            // TODO assembly management - reuse type, base on... hash of something?
            
            var assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule("DynamicQueryable");
            var type = module.DefineType("Anonymous", TypeAttributes.Public | TypeAttributes.Sealed);
            foreach (var entry in fields) type.DefineField(entry.Key, entry.Value, FieldAttributes.Public);
            var target = type.CreateTypeInfo().AsType();
            var parameter = Expression.Parameter(source);
            var bindings = fields.Select(entry => Expression.Bind(target.GetField(entry.Key), Expression.Property(parameter, entry.Key)));
            var body = Expression.MemberInit(Expression.New(target), bindings);
            var selector = Expression.Lambda(body, parameter);
            var call = Expression.Call(typeof(Queryable), "Select", new[] { source, target }, queryable.Expression, selector);
            var query = queryable.Provider.CreateQuery<dynamic>(call);
            return query;
        }
    }
}