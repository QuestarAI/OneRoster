namespace Questar.OneRoster.ApiFramework.Requests
{
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using Sorting;

    public class CollectionEndpointRequest<T> : EndpointRequest<T>
    {
        [FromQuery]
        public int Limit { get; set; } = Constants.DefaultLimit;

        [FromQuery]
        public int Offset { get; set; } = Constants.DefaultOffset;

        [FromQuery]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Sort { get; set; }

        [FromQuery]
        public SortDirection? OrderBy { get; set; }

        [FromQuery]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
}