namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/results")]
    public class ResultsController : Controller
    {
        /// <summary>
        /// Returns the collection of results.
        /// </summary>
        [HttpGet]
        public object GetAllResults() => throw new NotImplementedException();

        /// <summary>
        /// Marks a specific result as deleted by identifier.
        /// An immediate GET will result in HTTP 404 code.
        /// </summary>
        [HttpDelete("{resultId}")]
        public object DeleteResult(Guid resultId) => throw new NotImplementedException();

        /// <summary>
        /// Returns specific result by identifier.
        /// </summary>
        [HttpGet("{resultId}")]
        public object GetResult(Guid resultId) => throw new NotImplementedException();

        /// <summary>
        /// Creates or replaces a result by identifier.
        /// </summary>
        [HttpPut("{resultId}")]
        public object PutResult(Guid resultId) => throw new NotImplementedException();
    }
}