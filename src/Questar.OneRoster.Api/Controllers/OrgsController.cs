namespace Questar.OneRoster.Api.Controllers
{
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/orgs")]
    public class OrgsController : BaseController<Org>
    {
        public OrgsController(IWorkspace workspace) : base(workspace)
        {
        }
    }
}