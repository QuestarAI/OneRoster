namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/terms")]
    public class TermsController : Controller
    {
        /// <summary>
        /// Return collection of terms. A Term is an instance of an AcademicSession.
        /// </summary>
        public object GetAllTerms() => throw new NotImplementedException();

        /// <summary>
        /// Return specific term.
        /// </summary>
        public object GetTerm(Guid academicSessionId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of classes that are taught in this term.
        /// </summary>
        public object GetClassesForTerm(Guid academicSessionId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of Grading Periods that are part of this term.
        /// </summary>
        public object GetGradingPeriodsForTerm(Guid academicSessionId) => throw new NotImplementedException();
    }
}