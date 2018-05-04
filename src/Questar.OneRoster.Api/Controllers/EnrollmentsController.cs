namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/enrollments")]
    public class EnrollmentsController : Controller
    {
        /// <summary>
        /// Returns the collection of enrollments.
        /// </summary>
        [HttpGet]
        public object GetAllEnrollments() => throw new NotImplementedException();

        /// <summary>
        /// Returns a specific enrollment by identifier.
        /// </summary>
        [HttpGet("{enrollmentId}")]
        public object GetEnrollment(Guid enrollmentId) => throw new NotImplementedException();
    }
}