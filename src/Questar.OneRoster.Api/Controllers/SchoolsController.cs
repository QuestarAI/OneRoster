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
        public object GetAllSchools() => throw new NotImplementedException();

        /// <summary>
        /// Return specific school. A School is an instance of an Org.
        /// </summary>
        public object GetSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of courses taught by this school.
        /// </summary>
        public object GetCoursesForSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of classes taught by this school.
        /// </summary>
        public object GetClassesForSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of all enrollments into this class.
        /// </summary>
        public object GetEnrollmentsForClassInSchool(Guid orgId, Guid classId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of students taking this class in this school.
        /// </summary>
        public object GetStudentsForClassInSchool(Guid orgId, Guid classId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of teachers taking this class in this school.
        /// </summary>
        public object GetTeachersForClassInSchool(Guid orgId, Guid classId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of all enrollments for this school.
        /// </summary>
        public object GetEnrollmentsForSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of students attending this school.
        /// </summary>
        public object GetStudentsForSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of teachers teaching at this school.
        /// </summary>
        public object GetTeachersForSchool(Guid orgId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of terms that are used by this school.
        /// </summary>
        public object GetTermsForSchool(Guid orgId) => throw new NotImplementedException();
    }
}