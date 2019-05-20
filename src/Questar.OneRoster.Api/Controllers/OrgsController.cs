namespace Questar.OneRoster.Api.Controllers
{
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/orgs")]
    public class OrgsController : BaseController<Org>
    {
        public OrgsController(IOneRosterWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "Orgs",
            Singular = "Org"
        })
        {
        }

        protected override IQuery<Org> Query() => Workspace.Orgs.AsQuery();
    }
}