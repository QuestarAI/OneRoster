namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Route("ims/oneroster/v1p1/enrollments")]
    public class EnrollmentsController : OneRosterControllerDeprecated
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