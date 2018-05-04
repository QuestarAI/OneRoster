namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/resources")]
    public class ResourcesController : Controller
    {
        /// <summary>
        /// Return collection of resources.
        /// </summary>
        public object GetAllResources() => throw new NotImplementedException();

        /// <summary>
        /// Return specific resource.
        /// </summary>
        public object GetResource(Guid resourceId) => throw new NotImplementedException();
    }
}