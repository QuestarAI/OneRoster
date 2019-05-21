namespace Questar.OneRoster.Api.Controllers
{
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/demographics")]
    public class DemographicsController : BaseController<Demographics>
    {
        public DemographicsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Demographics> Query() => Workspace.Demographics.AsQuery();
    }
}