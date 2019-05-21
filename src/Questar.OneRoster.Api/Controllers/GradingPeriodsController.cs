namespace Questar.OneRoster.Api.Controllers
{
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/gradingPeriods")]
    public class GradingPeriodsController : BaseController<AcademicSession>
    {
        public GradingPeriodsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<AcademicSession> Query() => Workspace.AcademicSessions.AsQuery().Where(session => session.Type == AcademicSessionType.GradingPeriod);
    }
}