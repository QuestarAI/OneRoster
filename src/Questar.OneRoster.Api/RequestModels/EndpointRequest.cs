namespace Questar.OneRoster.Api.RequestModels
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class EndpointRequest<T>
    {
        [FromQuery]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Fields { get; set; }
    }
}