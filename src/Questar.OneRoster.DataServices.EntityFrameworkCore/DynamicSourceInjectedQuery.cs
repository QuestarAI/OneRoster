namespace Questar.OneRoster.DataServices.EntityFrameworkCore.Refactor
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using AutoMapper.Extensions.ExpressionMapping.Impl;
    using Filtering;
    using Sorting;

    public class DynamicSourceInjectedQuery : SourceInjectedQuery<dynamic>
    {
        public DynamicSourceInjectedQuery(ISourceInjectedQueryable<dynamic> source) : base(source)
        {
        }

        protected override Expression<Func<object, object, bool>> KeyComparer
            => throw new NotSupportedException("Feature is unavailable when using dynamic objects.");

        protected override Expression<Func<dynamic, object>> KeySelector
            => throw new NotSupportedException("Feature is unavailable when using dynamic objects.");

        public override IQuery<dynamic> Select(IEnumerable<string> fields)
            => throw new NotSupportedException("Feature is unavailable when using dynamic objects.");

        public override IQuery<dynamic> Sort(string field, SortDirection? direction)
            => throw new NotSupportedException("Feature is unavailable when using dynamic objects.");

        public override IQuery<dynamic> Where(Filter predicate)
            => throw new NotSupportedException("Feature is unavailable when using dynamic objects.");

        public override IQuery<dynamic> WhereHasKey(object key)
            => throw new NotSupportedException("Feature is unavailable when using dynamic objects.");
    }
}