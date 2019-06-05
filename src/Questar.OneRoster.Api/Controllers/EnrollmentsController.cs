using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/enrollments")]
    public class EnrollmentsController : BaseController<Enrollment>
    {
        public EnrollmentsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Enrollment> Query()
        {
            return Workspace.Enrollments.AsQuery();
        }
    }
}