using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using Questar.OneRoster.Filtering;
using Questar.OneRoster.Models;
using Questar.OneRoster.Sorting;

namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    public class BaseQuery<T> : Query<T>
        where T : Base
    {
        public BaseQuery(IQueryable<T> source)
            : base(source)
        {
        }

        public override IQuery<dynamic> Select(PropertyInfo[] properties)
        {
            var assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule("DynamicQueryable");
            var type = module.DefineType("Anonymous", TypeAttributes.Public | TypeAttributes.Sealed);
            foreach (var property in properties)
                type.DefineField(property.Name, property.PropertyType, FieldAttributes.Public);
            var parameter = Expression.Parameter(typeof(T));
            var instance = Expression.New(type.CreateTypeInfo());
            var bindings = properties.Select(property => Expression.Bind(instance.Type.GetField(property.Name), Expression.Property(parameter, property)));
            var body = Expression.MemberInit(instance, bindings);
            var selector = Expression.Lambda(body, parameter);
            var call = Expression.Call(typeof(Queryable), nameof(Queryable.Select), new[] {parameter.Type, instance.Type}, Source.Expression, selector);
            var query = Source.Provider.CreateQuery<dynamic>(call);
            return new DynamicQuery(query);
        }

        public override IQuery<T> Sort(string field, SortDirection? direction)
        {
            return new BaseQuery<T>(Source.SortBy(field, direction));
        }

        public override IQuery<T> Where(Filter predicate)
        {
            return new BaseQuery<T>(Source.Where(predicate.ToFilterExpression<T>()));
        }

        public override IQuery<T> WhereHasSourcedId(string sourcedId)
        {
            return new BaseQuery<T>(Source.Where(entity => entity.SourcedId == sourcedId));
        }
    }
}