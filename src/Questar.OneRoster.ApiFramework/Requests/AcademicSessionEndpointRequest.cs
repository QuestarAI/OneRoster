namespace Questar.OneRoster.ApiFramework.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class AcademicSessionEndpointRequest : EndpointRequest<AcademicSession>
    {
        [Required]
        [FromRoute]
        public Guid AcademicSessionId { get; set; }
    }
}