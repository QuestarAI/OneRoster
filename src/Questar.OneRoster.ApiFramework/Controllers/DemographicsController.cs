namespace Questar.OneRoster.ApiFramework.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/demographics")]
    public class DemographicsController : OneRosterController<Demographics>
    {
        public DemographicsController(IWorkspace workspace) : base(workspace)
        {
        }
    }
}