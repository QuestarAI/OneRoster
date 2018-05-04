namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/orgs")]
    public class OrgsController : Controller
    {
        /// <summary>
        /// Return collection of Orgs.
        /// </summary>
        public object GetAllOrgs() => throw new NotImplementedException();

        /// <summary>
        /// Return specific Org.
        /// </summary>
        public object GetOrg(Guid orgId) => throw new NotImplementedException();
    }
}