namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/demographics")]
    public class DemographicsController : Controller
    {
        /// <summary>
        /// Return collection of demographics.
        /// </summary>
        public object GetAllDemographics() => throw new NotImplementedException();

        /// <summary>
        /// Return specific demographics.
        /// </summary>
        public object GetDemographics(Guid demographicsId) => throw new NotImplementedException();
    }
}