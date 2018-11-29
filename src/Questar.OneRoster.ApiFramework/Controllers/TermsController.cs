namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Route("ims/oneroster/v1p1/terms")]
    public class TermsController : OneRosterController
    {
        /// <summary>
        /// Returns the collection of terms.
        /// A term is an instance of an academic session.
        /// </summary>
        [HttpGet]
        public object GetAllTerms() => throw new NotImplementedException();

        /// <summary>
        /// Returns a specific term by identifier.
        /// A term is an instance of an academic session.
        /// </summary>
        [HttpGet("{academicSessionId}")]
        public object GetTerm(Guid academicSessionId) => throw new NotImplementedException();

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