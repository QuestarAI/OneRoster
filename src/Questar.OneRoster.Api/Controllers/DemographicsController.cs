namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/demographics")]
    public class DemographicsController : Controller
    {
        /// <summary>
        /// Returns the collection of demographics.
        /// </summary>
        [HttpGet]
        public object GetAllDemographics() => throw new NotImplementedException();

        /// <summary>
        /// Returns a specific demographics object by identifier.
        /// </summary>
        [HttpGet("{demographicsId}")]
        public object GetDemographics(Guid demographicsId) => throw new NotImplementedException();
    }
}