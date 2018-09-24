namespace Questar.OneRoster.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Dto;
    using Microsoft.AspNetCore.Mvc;
    using Extensions;
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
        public async Task<ActionResult<IEnumerable<dynamic>>> GetAllAcademicSessionsAsync(CollectionEndpointRequest<AcademicSession> request)
            => Ok(await _context.AcademicSessions.ToListAsync(request));

        /// <summary>
        /// Returns a specific academic session by identifier.
        /// </summary>
        [HttpGet("{academicSessionId}")]
        public async Task<ActionResult<AcademicSessionDto>> GetAcademicSessionAsync(AcademicSessionEndpointRequest request)
        {
            var academicSession = await _context.AcademicSessions.FindAsync(request.AcademicSessionId);
            // TODO: Handle mapping in a more robust manner.
            var mapper = Mapping.BuildMapper();
            var academicSessionDto = mapper.Map<AcademicSessionDto>(academicSession);
            return Ok(academicSessionDto);
        }
    }
}