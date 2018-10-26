namespace Questar.OneRoster.Api.RequestModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using Microsoft.AspNetCore.Mvc;

    public class EndpointRequest<T>
    {
        [FromQuery]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Fields { get; set; }

        /// Deriving classes should implement this method, returning a predicate.
        /// In the case of a <see cref="CollectionEndpointRequest{T}"/>, it will be &&'d
        /// together with the predicate generated from <see cref="CollectionEndpointRequest{T}.Filter" />.
        public virtual Expression<Func<T, bool>> GetUrlPredicate() => null;
    }
}