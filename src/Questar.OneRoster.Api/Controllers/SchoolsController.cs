namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/schools")]
    public class SchoolsController : BaseController<Org>
    {
        public SchoolsController(IOneRosterWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "Orgs",
            Singular = "Org"
        })
        {
        }

        protected override IQuery<Org> Query() => Workspace.Schools.AsQuery();

        /// <summary>
        /// Returns the collection of courses taught in this school.
        /// </summary>
        [HttpGet("{orgId}/courses")]
        public Task<ActionResult> GetCoursesForSchool(string orgId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of classes taught in this school.
        /// </summary>
        [HttpGet("{orgId}/classes")]
        public Task<ActionResult> GetClassesForSchool(string orgId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of enrollments of this class in this school.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/enrollments")]
        public Task<ActionResult> GetEnrollmentsForClassInSchool(string orgId, string classId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of students taking this class in this school.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/students")]
        public Task<ActionResult> GetStudentsForClassInSchool(string orgId, string classId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of teachers teaching this class in this school.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/teachers")]
        public Task<ActionResult> GetTeachersForClassInSchool(string orgId, string classId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of enrollments in this school.
        /// </summary>
        [HttpGet("{orgId}/enrollments")]
        public Task<ActionResult> GetEnrollmentsForSchool(string orgId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of students attending this school.
        /// </summary>
        [HttpGet("{orgId}/students")]
        public Task<ActionResult> GetStudentsForSchool(string orgId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of teachers teaching at this school.
        /// </summary>
        [HttpGet("{orgId}/teachers")]
        public Task<ActionResult> GetTeachersForSchool(string orgId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of terms used by this school.
        /// </summary>
        [HttpGet("{orgId}/terms")]
        public object GetTermsForSchool(string orgId) => throw new NotImplementedException();
    }
}