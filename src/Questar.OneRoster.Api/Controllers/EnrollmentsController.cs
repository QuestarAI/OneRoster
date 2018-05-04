namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/enrollments")]
    public class EnrollmentsController : Controller
    {
        /// <summary>
        /// Return collection of all enrollments.
        /// </summary>
        [HttpGet]
        public object GetAllEnrollments() => throw new NotImplementedException();

        /// <summary>
        /// Return specific enrollment.
        /// </summary>
        [HttpGet("{enrollmentId}")]
        public object GetEnrollment(Guid enrollmentId) => throw new NotImplementedException();
    }
}