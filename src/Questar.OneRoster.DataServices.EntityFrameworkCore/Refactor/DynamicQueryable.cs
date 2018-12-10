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
        public static IQueryable<dynamic> DynamicSelect<T>(this IQueryable<T> queryable, IEnumerable<string> properties)
            => queryable.DynamicSelect(properties.Select(property => typeof(T).GetProperty(property, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)).ToArray());

        public static IQueryable<dynamic> DynamicSelect<T>(this IQueryable<T> queryable, PropertyInfo[] properties)
        {
            // TODO assembly management - reuse type, base on... hash of something?
            var assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule("DynamicQueryable");
            var type = module.DefineType("Anonymous", TypeAttributes.Public | TypeAttributes.Sealed);
            foreach (var property in properties) type.DefineField(property.Name, property.PropertyType, FieldAttributes.Public);
            var parameter = Expression.Parameter(typeof(T));
            var instance = Expression.New(type.CreateTypeInfo());
            var bindings = properties.Select(property => Expression.Bind(instance.Type.GetField(property.Name), Expression.Property(parameter, property)));
            var body = Expression.MemberInit(instance, bindings);
            var selector = Expression.Lambda(body, parameter);
            var call = Expression.Call(typeof(Queryable), "Select", new[] { parameter.Type, instance.Type }, queryable.Expression, selector);
            var query = queryable.Provider.CreateQuery<dynamic>(call);
            return query;
        }
    }
}