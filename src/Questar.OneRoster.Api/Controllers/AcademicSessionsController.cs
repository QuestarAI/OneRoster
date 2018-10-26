namespace Questar.OneRoster.Api.Controllers
{
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Dto;
    using Microsoft.AspNetCore.Mvc;
    using RequestModels;

    public class AcademicSessionsController : OneRosterController
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
        public Task<IActionResult> GetAllAcademicSessionsAsync(CollectionEndpointRequest<AcademicSession> request)
            => GetCollectionAsync(_context.AcademicSessions, request, (response, list) => response.AcademicSessions = list);

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