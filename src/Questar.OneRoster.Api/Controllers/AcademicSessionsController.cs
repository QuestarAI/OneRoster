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
    using RequestModels;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/academicSessions")]
    public class AcademicSessionsController : Controller
    {
        private readonly OneRosterDbContext _context;

        public AcademicSessionsController(OneRosterDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns the collection of all academic sessions.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IList<AcademicSessionDto>>> GetAllAcademicSessions(CollectionEndpointRequest<AcademicSession> request)
        {
            var academicSessions = await _context.AcademicSessions.ToListAsync();
            var academicSessionsDtos = academicSessions.Select(academicSession => new AcademicSessionDto()); // TODO automapper

            return Ok(academicSessionsDtos);
        }

        /// <summary>
        /// Returns a specific academic session by identifier.
        /// </summary>
        [HttpGet("{academicSessionId}")]
        public async Task<ActionResult<AcademicSessionDto>> GetAcademicSession(AcademicSessionEndpointRequest request)
        {
            var academicSession = await _context.AcademicSessions.FindAsync(request.AcademicSessionId);
            var academicSessionDto = new AcademicSessionDto(); // TODO automapper

            return Ok(academicSessionDto);
        }
    }
}