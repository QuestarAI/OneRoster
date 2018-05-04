namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/academicSessions")]
    public class AcademicSessionsController : Controller
    {
        /// <summary>
        /// Return collection of all academic sessions.
        /// </summary>
        [HttpGet]
        public object GetAllAcademicSessions() => throw new NotImplementedException();

        /// <summary>
        /// Return specific Academic Session.
        /// </summary>
        /// <param name="academicSessionId">The academic session identifier.</param>
        [HttpGet("{academicSessionId}")]
        public object GetAcademicSession(Guid academicSessionId) => throw new NotImplementedException();
    }
}