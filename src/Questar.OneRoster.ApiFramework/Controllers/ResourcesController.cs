namespace Questar.OneRoster.ApiFramework.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/resources")]
    public class ResourcesController : BaseController<Resource>
    {
        public ResourcesController(IWorkspace workspace) : base(workspace)
        {
        }
    }
}