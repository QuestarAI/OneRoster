namespace Questar.OneRoster.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class SingleParams : Params
    {
        [Required]
        [FromRoute]
        public string SourcedId { get; set; }
    }
}