namespace Questar.OneRoster.Api.Controllers
{
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/academicSessions")]
    public class AcademicSessionsController : BaseController<AcademicSession>
    {
        public AcademicSessionsController(IOneRosterWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "AcademicSessions",
            Singular = "AcademicSession"
        })
        {
        }

        protected override IQuery<AcademicSession> Query() => Workspace.AcademicSessions.AsQuery();
    }
}