namespace Questar.OneRoster.ApiFramework.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class DeleteRequest : Request
    {
        [Required]
        [FromRoute]
        public Guid Id { get; set; }
    }
}