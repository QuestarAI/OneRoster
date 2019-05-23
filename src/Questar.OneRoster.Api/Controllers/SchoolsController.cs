namespace Questar.OneRoster.Api.Controllers
{
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;
    using Payloads;

    [Route("ims/oneroster/v1p1/schools")]
    public class SchoolsController : BaseController<Org>
    {
        public SchoolsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Org> Query() =>
            Workspace.Schools.AsQuery();

        /// <summary>
        /// Returns the collection of courses taught in this school.
        /// </summary>
        [HttpGet("{orgId}/courses")]
        public Task<ActionResult<Payload<dynamic[]>>> GetCoursesForSchool(string orgId, SelectParams @params) =>
            Select(() => Workspace.Schools.GetCoursesForSchool(orgId), @params);

        /// <summary>
        /// Returns the collection of classes taught in this school.
        /// </summary>
        [HttpGet("{orgId}/classes")]
        public Task<ActionResult<Payload<dynamic[]>>> GetClassesForSchool(string orgId, SelectParams @params) =>
            Select(() => Workspace.Schools.GetClassesForSchool(orgId), @params);

        /// <summary>
        /// Returns the collection of enrollments of this class in this school.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/enrollments")]
        public Task<ActionResult<Payload<dynamic[]>>> GetEnrollmentsForClassInSchool(string orgId, string classId, SelectParams @params) =>
            Select(() => Workspace.Schools.GetEnrollmentsForClassInSchool(orgId, classId), @params);

        /// <summary>
        /// Returns the collection of students taking this class in this school.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/students")]
        public Task<ActionResult<Payload<dynamic[]>>> GetStudentsForClassInSchool(string orgId, string classId, SelectParams @params) =>
            Select(() => Workspace.Schools.GetStudentsForClassInSchool(orgId, classId), @params);

        /// <summary>
        /// Returns the collection of teachers teaching this class in this school.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/teachers")]
        public Task<ActionResult<Payload<dynamic[]>>> GetTeachersForClassInSchool(string orgId, string classId, SelectParams @params) =>
            Select(() => Workspace.Schools.GetTeachersForClassInSchool(orgId, classId), @params);

        /// <summary>
        /// Returns the collection of enrollments in this school.
        /// </summary>
        [HttpGet("{orgId}/enrollments")]
        public Task<ActionResult<Payload<dynamic[]>>> GetEnrollmentsForSchool(string orgId, SelectParams @params) =>
            Select(() => Workspace.Schools.GetEnrollmentsForSchool(orgId), @params);

        /// <summary>
        /// Returns the collection of students attending this school.
        /// </summary>
        [HttpGet("{orgId}/students")]
        public Task<ActionResult<Payload<dynamic[]>>> GetStudentsForSchool(string orgId, SelectParams @params) =>
            Select(() => Workspace.Schools.GetStudentsForSchool(orgId), @params);

        /// <summary>
        /// Returns the collection of teachers teaching at this school.
        /// </summary>
        [HttpGet("{orgId}/teachers")]
        public Task<ActionResult<Payload<dynamic[]>>> GetTeachersForSchool(string orgId, SelectParams @params) =>
            Select(() => Workspace.Schools.GetTeachersForSchool(orgId), @params);

        /// <summary>
        /// Returns the collection of terms used by this school.
        /// </summary>
        [HttpGet("{orgId}/terms")]
        public Task<ActionResult<Payload<dynamic[]>>> GetTermsForSchool(string orgId, SelectParams @params) =>
            Select(() => Workspace.Schools.GetTermsForSchool(orgId), @params);
    }
}