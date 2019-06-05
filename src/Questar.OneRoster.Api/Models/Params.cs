using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Questar.OneRoster.Api.Models
{
    public abstract class Params
    {
        [FromQuery]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Fields { get; set; }
    }
}