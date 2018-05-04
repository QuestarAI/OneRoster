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
        public object GetAllEnrollments() => throw new NotImplementedException();

        /// <summary>
        /// Return specific enrollment.
        /// </summary>
        public object GetEnrollment(Guid enrollmentId) => throw new NotImplementedException();
    }
}