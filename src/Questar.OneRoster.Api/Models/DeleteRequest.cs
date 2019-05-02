namespace Questar.OneRoster.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class DeleteRequest : Request
    {
        [Required]
        [FromRoute]
        public Guid Id { get; set; }
    }
}