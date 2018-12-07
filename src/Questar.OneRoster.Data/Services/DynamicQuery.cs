namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Threading.Tasks;

    public class DynamicQuery<T> : IDynamicQuery
    {
        public DynamicQuery(IQueryable<T> source, IEnumerable<string> fields)
        {
            Source = source;
            Members = fields.ToList();
        }

        protected IQueryable<T> Source { get; }

        public IEnumerable<string> Members { get; }

        public object Single() => Source.Single();

        // TODO check async enumerable support non-enumerable return values
        public async Task<object> SingleAsync() => await Task.FromResult(Invoke(Source).Single());

        IList IQuery.ToList() => ToList();

        async Task<IList> IQuery.ToListAsync() => await ToListAsync();

        protected IQueryable<dynamic> Invoke(IQueryable<T> queryable)
        {
            var properties = Members.ToDictionary(member => member, member =>
            {
                var property = typeof(T).GetProperty(member, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property == null)
                    throw new InvalidOperationException($"Could not find property '{member}' on type '{typeof(T).Name}'.");
                return property.PropertyType;
            });

            // TODO get full path

            var sourceType = typeof(T);
            var targetType = CreateAnonymousType(properties);
            var parameter = Expression.Parameter(sourceType);
            var bindings = properties.Select(entry => Expression.Bind(targetType.GetField(entry.Key) ?? throw new InvalidOperationException("Couldn't find the property."), Expression.Property(parameter, entry.Key)));
            var body = Expression.MemberInit(Expression.New(targetType), bindings);
            var selector = Expression.Lambda(body, parameter);
            var call = Expression.Call(typeof(Queryable), "Select", new[] {sourceType, targetType}, Source.Expression, selector);
            var query = queryable.Provider.CreateQuery<dynamic>(call);
            return query;
        }

        public List<dynamic> ToList() => Invoke(Source).AsEnumerable().ToList();

        public Task<List<dynamic>> ToListAsync() => Invoke(Source).ToAsyncEnumerable().ToList();

        private static Type CreateAnonymousType(IDictionary<string, Type> properties)
        {
            var assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule("Dynamics");
            var type = module.DefineType("Anonymous", TypeAttributes.Public | TypeAttributes.Class);
            foreach (var entry in properties) type.DefineField(entry.Key, entry.Value, FieldAttributes.Public);
            return type.CreateTypeInfo().AsType();
        }
    }
}