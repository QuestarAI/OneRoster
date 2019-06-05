using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Questar.OneRoster.Api.Models
{
    public class UpsertParams<T> : Params
    {
        [Required] [FromRoute] public string SourcedId { get; set; }

        [Required] [FromBody] public T Data { get; set; }
    }
}