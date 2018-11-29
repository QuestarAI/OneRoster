namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Route("ims/oneroster/v1p1/resources")]
    public class ResourcesController : OneRosterControllerDeprecated
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