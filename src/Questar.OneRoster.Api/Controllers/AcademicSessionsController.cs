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
            // TODO: Handle mapping in a more robust manner.
            var mapper = Mapping.BuildMapper();
            var academicSessionsDtos = academicSessions.Select(mapper.Map<AcademicSessionDto>);
            return Ok(academicSessionsDtos);
        }

        /// <summary>
        /// Returns a specific academic session by identifier.
        /// </summary>
        [HttpGet("{academicSessionId}")]
        public async Task<ActionResult<AcademicSessionDto>> GetAcademicSession(AcademicSessionEndpointRequest request)
        {
            var academicSession = await _context.AcademicSessions.FindAsync(request.AcademicSessionId);
            // TODO: Handle mapping in a more robust manner.
            var mapper = Mapping.BuildMapper();
            var academicSessionDto = mapper.Map<AcademicSessionDto>(academicSession);
            return Ok(academicSessionDto);
        }
    }
}