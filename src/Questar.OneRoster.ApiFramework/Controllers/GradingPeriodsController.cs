namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Route("ims/oneroster/v1p1/gradingPeriods")]
    public class GradingPeriodsController : OneRosterController
    {
        /// <summary>
        /// Returns the collection of grading periods.
        /// A grading period is an instance of an academic session.
        /// </summary>
        [HttpGet]
        public object GetAllGradingPeriods() => throw new NotImplementedException();

        /// <summary>
        /// Returns specific grading period by identifier.
        /// A grading period is an instance of an academic session.
        /// </summary>
        [HttpGet("{academicSessionId}")]
        public object GetGradingPeriod(Guid academicSessionId) => throw new NotImplementedException();
    }
}