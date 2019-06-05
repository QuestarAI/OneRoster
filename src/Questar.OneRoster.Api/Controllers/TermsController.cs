using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.Api.Models;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;
using Questar.OneRoster.Payloads;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/terms")]
    public class TermsController : BaseController<AcademicSession>
    {
        public TermsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<AcademicSession> Query()
        {
            return Workspace.Terms.AsQuery();
        }

        /// <summary>
        ///     Returns the collection of classes taught in this term.
        /// </summary>
        [HttpGet("{academicSessionId}/classes")]
        public Task<ActionResult<Payload<dynamic[]>>> GetClassesForTerm(string academicSessionId, SelectParams @params)
        {
            return Select(() => Workspace.Terms.GetClassesForTerm(academicSessionId), @params);
        }

        /// <summary>
        ///     Returns the collection of grading periods which are part of this term.
        /// </summary>
        [HttpGet("{academicSessionId}/gradingPeriods")]
        public Task<ActionResult<Payload<dynamic[]>>> GetGradingPeriodsForTerm(string academicSessionId, SelectParams @params)
        {
            return Select(() => Workspace.Terms.GetGradingPeriodsForTerm(academicSessionId), @params);
        }
    }
}