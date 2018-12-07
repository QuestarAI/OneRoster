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
            // TODO extract?

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
            var bindings = properties.Select(entry => Expression.Bind(targetType.GetProperty(entry.Key) ?? throw new InvalidOperationException("Couldn't find the property."), Expression.Property(parameter, entry.Key)));
            var body = Expression.MemberInit(Expression.New(targetType), bindings);
            var selector = Expression.Lambda(body, parameter);
            var call = Expression.Call(typeof(Queryable), "Select", new[] {sourceType, targetType}, Source.Expression, selector);
            var query = queryable.Provider.CreateQuery<dynamic>(call);
            return query;
        }

        public List<dynamic> ToList() => Invoke(Source).AsEnumerable().ToList();

        public Task<List<dynamic>> ToListAsync() => Invoke(Source).ToAsyncEnumerable().ToList();

        // TODO clean this up - lots seems unnecessary
        private static Type CreateAnonymousType(IDictionary<string, Type> properties)
        {
            var assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule("Dynamics");
            var type = module.DefineType("Anonymous", TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.AutoLayout);

            type.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);

            foreach (var entry in properties)
            {
                var field = type.DefineField("_" + entry.Key, entry.Value, FieldAttributes.Private);

                var property = type.DefineProperty(entry.Key, PropertyAttributes.HasDefault, entry.Value, null);
                var propertyGetter = type.DefineMethod($"get_{entry.Key}", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, entry.Value, Type.EmptyTypes);
                var propertyGetterIl = propertyGetter.GetILGenerator();

                propertyGetterIl.Emit(OpCodes.Ldarg_0);
                propertyGetterIl.Emit(OpCodes.Ldfld, field);
                propertyGetterIl.Emit(OpCodes.Ret);

                var propertySetter = type.DefineMethod($"set_{entry.Key}", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new[] {entry.Value});
                var propertySetterIl = propertySetter.GetILGenerator();

                propertySetterIl.MarkLabel(propertySetterIl.DefineLabel());
                propertySetterIl.Emit(OpCodes.Ldarg_0);
                propertySetterIl.Emit(OpCodes.Ldarg_1);
                propertySetterIl.Emit(OpCodes.Stfld, field);

                propertySetterIl.Emit(OpCodes.Nop);
                propertySetterIl.MarkLabel(propertySetterIl.DefineLabel());
                propertySetterIl.Emit(OpCodes.Ret);

                property.SetGetMethod(propertyGetter);
                property.SetSetMethod(propertySetter);
            }

            return type.CreateTypeInfo().AsType();
        }
    }
}