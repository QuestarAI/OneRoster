namespace Questar.OneRoster.Api.RequestModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class AcademicSessionEndpointRequest : EndpointRequest<AcademicSession>
    {
        [Required]
        public Guid AcademicSessionId { get; set; }
    }
}