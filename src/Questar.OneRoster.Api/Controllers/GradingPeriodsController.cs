using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.DataServices.Filtering;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/gradingPeriods")]
    public class GradingPeriodsController : BaseController<AcademicSession>
    {
        public GradingPeriodsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<AcademicSession> Query()
        {
            return Workspace.AcademicSessions.AsQuery().Where(session => session.Type == AcademicSessionType.GradingPeriod);
        }
    }
}