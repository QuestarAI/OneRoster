namespace Questar.OneRoster.ApiFramework.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/academicSessions")]
    public class AcademicSessionsController : OneRosterController<AcademicSession>
    {
        public AcademicSessionsController(IWorkspace workspace) : base(workspace)
        {
        }
    }
}