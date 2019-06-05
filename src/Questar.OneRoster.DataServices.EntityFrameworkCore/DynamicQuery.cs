using System;
using System.Linq;
using System.Reflection;
using Questar.OneRoster.Filtering;
using Questar.OneRoster.Sorting;

namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    public class DynamicQuery : Query<dynamic>
    {
        public DynamicQuery(IQueryable<dynamic> source) : base(source)
        {
        }

        public override IQuery<dynamic> Select(PropertyInfo[] properties)
        {
            throw new NotSupportedException($"{nameof(Select)} is unavailable within the context of a dynamic object.");
        }

        public override IQuery<dynamic> Sort(string field, SortDirection? direction)
        {
            throw new NotSupportedException($"{nameof(Sort)} is unavailable within the context of a dynamic object.");
        }

        public override IQuery<dynamic> Where(Filter predicate)
        {
            throw new NotSupportedException($"{nameof(Where)} is unavailable within the context of a dynamic object.");
        }

        public override IQuery<dynamic> WhereHasSourcedId(string sourcedId)
        {
            throw new NotSupportedException($"{nameof(WhereHasSourcedId)} is unavailable within the context of a dynamic object.");
        }
    }
}