namespace Questar.OneRoster.ApiFramework.Models.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class UpsertRequest<T> : Request
    {
        [Required]
        [FromRoute]
        public Guid Id { get; set; }

        [Required]
        [FromBody]
        public T Data { get; set; }
    }
}