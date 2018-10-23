namespace Questar.OneRoster.Api.RequestModels
{
    using Microsoft.AspNetCore.Mvc;

    public class EndpointRequest<T>
    {
        [FromQuery]
        public string Fields { get; set; }
    }
}