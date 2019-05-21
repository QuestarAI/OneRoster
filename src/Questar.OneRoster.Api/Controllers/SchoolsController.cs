namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/schools")]
    public class SchoolsController : BaseController<Org>
    {
        public SchoolsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Org> Query() => Workspace.Schools.AsQuery();

        /// <summary>
        /// Returns the collection of courses taught in this school.
        /// </summary>
        [HttpGet("{orgId}/courses")]
        public Task<ActionResult<dynamic>> GetCoursesForSchool(string orgId, SelectRequest request)
            => Select(() => Workspace.Schools.GetCoursesForSchool(orgId), request);

        /// <summary>
        /// Returns the collection of classes taught in this school.
        /// </summary>
        [HttpGet("{orgId}/classes")]
        public Task<ActionResult<dynamic>> GetClassesForSchool(string orgId, SelectRequest request)
            => Select(() => Workspace.Schools.GetClassesForSchool(orgId), request);

        /// <summary>
        /// Returns the collection of enrollments of this class in this school.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/enrollments")]
        public Task<ActionResult<dynamic>> GetEnrollmentsForClassInSchool(string orgId, string classId, SelectRequest request)
            => Select(() => Workspace.Schools.GetEnrollmentsForClassInSchool(orgId, classId), request);

        /// <summary>
        /// Returns the collection of students taking this class in this school.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/students")]
        public Task<ActionResult<dynamic>> GetStudentsForClassInSchool(string orgId, string classId, SelectRequest request)
            => Select(() => Workspace.Schools.GetStudentsForClassInSchool(orgId, classId), request);

        /// <summary>
        /// Returns the collection of teachers teaching this class in this school.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/teachers")]
        public Task<ActionResult<dynamic>> GetTeachersForClassInSchool(string orgId, string classId, SelectRequest request)
            => Select(() => Workspace.Schools.GetTeachersForClassInSchool(orgId, classId), request);

        /// <summary>
        /// Returns the collection of enrollments in this school.
        /// </summary>
        [HttpGet("{orgId}/enrollments")]
        public Task<ActionResult<dynamic>> GetEnrollmentsForSchool(string orgId, SelectRequest request)
            => Select(() => Workspace.Schools.GetEnrollmentsForSchool(orgId), request);

        /// <summary>
        /// Returns the collection of students attending this school.
        /// </summary>
        [HttpGet("{orgId}/students")]
        public Task<ActionResult<dynamic>> GetStudentsForSchool(string orgId, SelectRequest request)
            => Select(() => Workspace.Schools.GetStudentsForSchool(orgId), request);

        /// <summary>
        /// Returns the collection of teachers teaching at this school.
        /// </summary>
        [HttpGet("{orgId}/teachers")]
        public Task<ActionResult<dynamic>> GetTeachersForSchool(string orgId, SelectRequest request)
            => Select(() => Workspace.Schools.GetTeachersForSchool(orgId), request);

        /// <summary>
        /// Returns the collection of terms used by this school.
        /// </summary>
        [HttpGet("{orgId}/terms")]
        public Task<ActionResult<dynamic>> GetTermsForSchool(string orgId, SelectRequest request)
            => Select(() => Workspace.Schools.GetTermsForSchool(orgId), request);
    }
}