namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/gradingPeriods")]
    public class GradingPeriodsController : Controller
    {
        /// <summary>
        /// Return collection of grading periods. A Grading Period is an instance of an AcademicSession.
        /// </summary>
        public object GetAllGradingPeriods() => throw new NotImplementedException();

        /// <summary>
        /// Return specific Grading Period. A Grading Period is an instance of an AcademicSession.
        /// </summary>
        public object GetGradingPeriod(Guid academicSessionId) => throw new NotImplementedException();
    }
}