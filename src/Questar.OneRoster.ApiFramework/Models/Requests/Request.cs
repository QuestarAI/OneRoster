namespace Questar.OneRoster.ApiFramework.Models.Requests
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class Request
    {
        [FromQuery]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Fields { get; set; }
    }
}