namespace Questar.OneRoster.Api.RequestModels
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class EndpointRequest<T>
    {
        [FromQuery]
        public string Fields { get; set; }
    }
}