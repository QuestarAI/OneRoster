namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/terms")]
    public class TermsController : OneRosterController<AcademicSession>
    {
        public TermsController(IWorkspace workspace) : base(workspace)
        {
        }


        /// <summary>
        /// Returns the collection of classes taught in this term.
        /// </summary>
        [HttpGet("{academicSessionId}/classes")]
        public object GetClassesForTerm(Guid academicSessionId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of grading periods which are part of this term.
        /// </summary>
        [HttpGet("{academicSessionId}/gradingPeriods")]
        public object GetGradingPeriodsForTerm(Guid academicSessionId) => throw new NotImplementedException();
    }
}