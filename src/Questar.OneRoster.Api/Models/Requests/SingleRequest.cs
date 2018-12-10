namespace Questar.OneRoster.Api.Models.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class SingleRequest : Request
    {
        [Required]
        [FromRoute]
        public Guid SourcedId { get; set; }
    }
}