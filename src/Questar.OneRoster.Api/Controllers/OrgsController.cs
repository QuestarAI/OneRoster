using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/orgs")]
    public class OrgsController : BaseController<Org>
    {
        public OrgsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Org> Query()
        {
            return Workspace.Orgs.AsQuery();
        }
    }
}