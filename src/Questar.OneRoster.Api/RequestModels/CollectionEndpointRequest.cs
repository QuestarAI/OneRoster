namespace Questar.OneRoster.Api.RequestModels
{
    using System;
    using System.Linq.Expressions;
    using Microsoft.AspNetCore.Mvc;
    using Query;

    public class CollectionEndpointRequest<T> : EndpointRequest<T>
    {
        [FromQuery]
        public int Limit { get; set; } = 100;

        [FromQuery]
        public int Offset { get; set; } = 0;

        [FromQuery]
        public string Sort { get; set; }

        [FromQuery]
        public SortDirection? OrderBy { get; set; }

        [FromQuery]
        public string Filter { get; set; }

        public Expression<Func<T, bool>> BuildPredicate() => FilterExpressionBuilder<T>.FromString(Filter);
    }
}