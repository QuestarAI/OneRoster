namespace Questar.OneRoster.Api.RequestModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;

    public class AcademicSessionEndpointRequest : EndpointRequest<AcademicSession>
    {
        [Required]
        [FromRoute]
        public Guid AcademicSessionId { get; set; }
    }
}