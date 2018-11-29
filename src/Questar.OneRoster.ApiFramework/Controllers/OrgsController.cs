namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Route("ims/oneroster/v1p1/orgs")]
    public class OrgsController : OneRosterControllerDeprecated
    {
        /// <summary>
        /// Returns the collection of organizations.
        /// </summary>
        [HttpGet]
        public object GetAllOrgs() => throw new NotImplementedException();

        /// <summary>
        /// Returns a specific organization by identifier.
        /// </summary>
        [HttpGet("{orgId}")]
        public object GetOrg(Guid orgId) => throw new NotImplementedException();
    }
}