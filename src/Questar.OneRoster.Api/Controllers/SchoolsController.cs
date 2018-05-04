namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/schools")]
    public class SchoolsController : Controller
    {
        /// <summary>
        /// Return collection of schools. A School is an instance of an Org.
        /// </summary>
        [HttpGet]
        public object GetAllSchools() => throw new NotImplementedException();

        /// <summary>
        /// Return specific school. A School is an instance of an Org.
        /// </summary>
        [HttpGet("{orgId}")]
        public object GetSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of courses taught by this school.
        /// </summary>
        [HttpGet("{orgId}/courses")]
        public object GetCoursesForSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of classes taught by this school.
        /// </summary>
        [HttpGet("{orgId}/classes")]
        public object GetClassesForSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of all enrollments into this class.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/enrollments")]
        public object GetEnrollmentsForClassInSchool(Guid orgId, Guid classId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of students taking this class in this school.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/students")]
        public object GetStudentsForClassInSchool(Guid orgId, Guid classId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of teachers taking this class in this school.
        /// </summary>
        [HttpGet("{orgId}/classes/{classId}/teachers")]
        public object GetTeachersForClassInSchool(Guid orgId, Guid classId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of all enrollments for this school.
        /// </summary>
        [HttpGet("{orgId}/enrollments")]
        public object GetEnrollmentsForSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of students attending this school.
        /// </summary>
        [HttpGet("{orgId}/students")]
        public object GetStudentsForSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of teachers teaching at this school.
        /// </summary>
        [HttpGet("{orgId}/teachers")]
        public object GetTeachersForSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of terms that are used by this school.
        /// </summary>
        [HttpGet("{orgId}/terms")]
        public object GetTermsForSchool(Guid orgId) => throw new NotImplementedException();
    }
}