namespace Questar.OneRoster.ApiFramework.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/gradingPeriods")]
    public class GradingPeriodsController : BaseController<AcademicSession>
    {
        public GradingPeriodsController(IWorkspace workspace) : base(workspace)
        {
        }
    }
}