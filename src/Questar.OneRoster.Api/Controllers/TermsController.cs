namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;
    using OneRoster.Models.Errors;

    [Route("ims/oneroster/v1p1/terms")]
    public class TermsController : BaseController<AcademicSession>
    {
        public TermsController(IOneRosterWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "AcademicSessions",
            Singular = "AcademicSession"
        })
        {
        }

        protected override IQuery<AcademicSession> Query() => Workspace.Terms.AsQuery();

        /// <summary>
        /// Returns the collection of classes taught in this term.
        /// </summary>
        [HttpGet("{academicSessionId}/classes")]
        public async Task<ActionResult> GetClassesForTerm(string academicSessionId)
        {
            // TODO serialization
            var classes = await Workspace.Terms.GetClassesForTerm(academicSessionId).ToPageAsync(0, 100);
            HttpContext.Response.Headers.Add("X-Total-Count", classes.Count.ToString());
            return Ok(new
            {
                Classes = classes.Items.ToList(),
                StatusInfoSet = Array.Empty<StatusInfo>(),
            });
        }

        /// <summary>
        /// Returns the collection of grading periods which are part of this term.
        /// </summary>
        [HttpGet("{academicSessionId}/gradingPeriods")]
        public async Task<ActionResult> GetGradingPeriodsForTerm(string academicSessionId)
        {
            // TODO serialization
            var sessions = await Workspace.Terms.GetGradingPeriodsForTerm(academicSessionId).ToPageAsync(0, 100);
            HttpContext.Response.Headers.Add("X-Total-Count", sessions.Count.ToString());
            return Ok(new
            {
                AcademicSessions = sessions.Items.ToList(),
                StatusInfoSet = Array.Empty<StatusInfo>(),
            });
        }
    }
}