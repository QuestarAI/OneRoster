namespace Questar.OneRoster.ApiFramework.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/orgs")]
    public class OrgsController : OneRosterController<Org>
    {
        public OrgsController(IWorkspace workspace) : base(workspace)
        {
        }
    }
}