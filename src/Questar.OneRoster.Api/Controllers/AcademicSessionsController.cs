namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Dto;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/academicSessions")]
    public class AcademicSessionsController : Controller
    {
        public OneRosterDbContext Context { get; }

        public AcademicSessionsController(OneRosterDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Returns the collection of all academic sessions.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IList<AcademicSessionDto>>> GetAllAcademicSessions()
        {
            var academicSessions = await Context.AcademicSessions.ToListAsync();
            var academicSessionsDtos = academicSessions.Select(academicSession => new AcademicSessionDto()); // TODO automapper

            return Ok(academicSessionsDtos);
        }

        /// <summary>
        /// Returns a specific academic session by identifier.
        /// </summary>
        /// <param name="academicSessionId">The academic session identifier.</param>
        [HttpGet("{academicSessionId}")]
        public async Task<ActionResult<AcademicSessionDto>> GetAcademicSession(Guid academicSessionId)
        {
            var academicSession = await Context.AcademicSessions.FindAsync(academicSessionId);
            var academicSessionDto = new AcademicSessionDto(); // TODO automapper

            return Ok(academicSessionDto);
        }
    }
}