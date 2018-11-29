namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Attributes;
    using Data;
    using Filtering;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Requests;

    [Route("ims/oneroster/v1p1/academicSessions")]
    public class AcademicSessionsController : OneRosterController // <AcademicSession>
    {
        //public AcademicSessionsController(IWorkspace workspace) : base(workspace);

        /// <summary>
        /// Returns the collection of all academic sessions.
        /// </summary>
        [HttpGet]
        [OneRosterResult("AcademicSessions")]
        public Task<IActionResult> GetAll(CollectionEndpointRequest<AcademicSession> request)
        {
            throw new NotImplementedException();
        }
        //=> this.ToPage<AcademicSession>(request);

        //var page =
        //        Query
        //            .For<AcademicSession>()
        //            .Where(Filter.Parse(request.Filter).ToFilterExpression())
        //            .SortBy(request.SortPath, request.SortDirection)
        //            .ToPage(request.Offset, request.Limit); -> IPage<AcademicSession>
        //            .ToPageModel()

        //var page =
        //        Query
        //            .For<AcademicSession>()
        //            .Where(Filter.Parse(request.Filter).ToFilterExpression())
        //            .SortBy(request.SortPath, request.SortDirection)
        //            .Fields(request.Fields) -> IQueryable<T> -> IQueryable
        //            .ToPage(request.Offset, request.Limit); -> IPage
        //            .ToPageModel()

        /// <summary>
        /// Returns a specific academic session by identifier.
        /// </summary>
        [HttpGet("{academicSessionId}")]
        [OneRosterResult("AcademicSession")]
        public async Task<IActionResult> Get(AcademicSessionEndpointRequest request)
        {
            throw new NotImplementedException();
        }

        //var item =
        //        Query
        //            .For<AcademicSession>()
        //            .Single(request.AcademicSessionId); -> AcademicSession

        //var item =
        //        Query
        //            .For<AcademicSession>()
        //            .Fields(request.Fields)
        //            .Single(request.AcademicSessionId); -> object
    }
}