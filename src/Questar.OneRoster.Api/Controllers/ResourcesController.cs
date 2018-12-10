namespace Questar.OneRoster.Api.Controllers
{
    using DataServices;
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