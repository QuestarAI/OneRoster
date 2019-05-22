namespace Questar.OneRoster.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class UpsertParams<T> : Params
    {
        [Required]
        [FromRoute]
        public string SourcedId { get; set; }

        [Required]
        [FromBody]
        public T Data { get; set; }
    }
}