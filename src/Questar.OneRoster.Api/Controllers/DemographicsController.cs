using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/demographics")]
    public class DemographicsController : BaseController<Demographics>
    {
        public DemographicsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Demographics> Query()
        {
            return Workspace.Demographics.AsQuery();
        }
    }
}