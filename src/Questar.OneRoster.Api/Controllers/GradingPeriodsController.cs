namespace Questar.OneRoster.Api.Controllers
{
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/gradingPeriods")]
    public class GradingPeriodsController : BaseController<AcademicSession>
    {
        public GradingPeriodsController(IWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "AcademicSessions",
            Singular = "AcademicSession"
        })
        {
        }

        protected override IQuery<AcademicSession> Query() => base.Query().Where(session => session.Type == AcademicSessionType.GradingPeriod);
    }
}