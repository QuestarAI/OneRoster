namespace Questar.OneRoster.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class UpsertRequest<T> : Request
    {
        [Required]
        [FromRoute]
        public string SourcedId { get; set; }

        [Required]
        [FromBody]
        public T Data { get; set; }
    }
}