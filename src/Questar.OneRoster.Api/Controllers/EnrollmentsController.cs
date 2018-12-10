namespace Questar.OneRoster.Api.Controllers
{
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/enrollments")]
    public class EnrollmentsController : BaseController<Enrollment>
    {
        public EnrollmentsController(IWorkspace workspace) : base(workspace)
        {
        }
    }
}