using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Questar.OneRoster.Api.Models
{
    public class DeleteParams : Params
    {
        [Required] [FromRoute] public string SourcedId { get; set; }
    }
}