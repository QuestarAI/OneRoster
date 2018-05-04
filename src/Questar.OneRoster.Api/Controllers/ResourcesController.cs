namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/resources")]
    public class ResourcesController : Controller
    {
        /// <summary>
        /// Returns the collection of resources.
        /// </summary>
        [HttpGet]
        public object GetAllResources() => throw new NotImplementedException();

        /// <summary>
        /// Returns a specific resource by identifier.
        /// </summary>
        [HttpGet("{resourceId}")]
        public object GetResource(Guid resourceId) => throw new NotImplementedException();
    }
}