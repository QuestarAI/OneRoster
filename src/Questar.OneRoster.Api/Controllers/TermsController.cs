namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/terms")]
    public class TermsController : BaseController<AcademicSession>
    {
        public TermsController(IWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "Terms",
            Singular = "Term"
        })
        {
        }

        protected override IQuery<AcademicSession> Query() => base.Query().Where(session => session.Type == AcademicSessionType.Term);

        /// <summary>
        /// Returns the collection of classes taught in this term.
        /// </summary>
        [HttpGet("{academicSessionId}/classes")]
        public object GetClassesForTerm(string academicSessionId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of grading periods which are part of this term.
        /// </summary>
        [HttpGet("{academicSessionId}/gradingPeriods")]
        public object GetGradingPeriodsForTerm(string academicSessionId) => throw new NotImplementedException();
    }
}