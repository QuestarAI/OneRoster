using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/resources")]
    public class ResourcesController : BaseController<Resource>
    {
        public ResourcesController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Resource> Query()
        {
            return Workspace.Resources.AsQuery();
        }
    }
}