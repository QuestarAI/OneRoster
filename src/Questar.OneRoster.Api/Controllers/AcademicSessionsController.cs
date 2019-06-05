using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/academicSessions")]
    public class AcademicSessionsController : BaseController<AcademicSession>
    {
        public AcademicSessionsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<AcademicSession> Query()
        {
            return Workspace.AcademicSessions.AsQuery();
        }
    }
}