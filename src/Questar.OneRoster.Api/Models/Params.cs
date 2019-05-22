namespace Questar.OneRoster.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class Params
    {
        [FromQuery]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Fields { get; set; }
    }
}