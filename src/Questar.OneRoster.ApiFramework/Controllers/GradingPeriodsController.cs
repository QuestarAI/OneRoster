namespace Questar.OneRoster.ApiFramework.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/gradingPeriods")]
    public class GradingPeriodsController : OneRosterController<AcademicSession>
    {
        public GradingPeriodsController(IWorkspace workspace) : base(workspace)
        {
        }
    }
}