namespace Questar.OneRoster.ApiFramework.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/enrollments")]
    public class EnrollmentsController : OneRosterController<Enrollment>
    {
        public EnrollmentsController(IWorkspace workspace) : base(workspace)
        {
        }
    }
}