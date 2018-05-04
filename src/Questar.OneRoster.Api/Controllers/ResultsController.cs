namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/results")]
    public class ResultsController : Controller
    {
        /// <summary>
        /// Return collection of results.
        /// </summary>
        [HttpGet]
        public object GetAllResults() => throw new NotImplementedException();

        /// <summary>
        /// Enable the associated SourcedId to be marked as deleted. An immediate read will result in 404 code.
        /// </summary>
        [HttpDelete("{resultId}")]
        public object DeleteResult(Guid resultId) => throw new NotImplementedException();

        /// <summary>
        /// Return specific result.
        /// </summary>
        [HttpGet("{resultId}")]
        public object GetResult(Guid resultId) => throw new NotImplementedException();

        /// <summary>
        /// To create a new Result record or to replace one that already exists.
        /// </summary>
        [HttpPut("{resultId}")]
        public object PutResult(Guid resultId) => throw new NotImplementedException();
    }
}