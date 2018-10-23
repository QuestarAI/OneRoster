namespace Questar.OneRoster.Api.RequestModels
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using Query;

    public class CollectionEndpointRequest<T> : EndpointRequest<T>
    {
        [FromQuery]
        public int Limit { get; set; } = Constants.DefaultLimit;

        [FromQuery]
        public int Offset { get; set; } = Constants.DefaultOffset;

        [FromQuery]
        public string Sort { get; set; }

        [FromQuery]
        public SortDirection? OrderBy { get; set; }

        [FromQuery]
        public string Filter { get; set; }

        /// Deriving classes should implement this method, returning a predicate to be &&'d together
        /// with the predicate generated from <see cref="Filter" />.
        public virtual Expression<Func<T, bool>> GetUrlPredicate() => null;
    }
}