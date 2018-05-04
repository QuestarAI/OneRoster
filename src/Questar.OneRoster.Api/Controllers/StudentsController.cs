namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/students")]
    public class StudentsController : Controller
    {
        /// <summary>
        /// Returns the collection of students.
        /// A student is an instance of a user.
        /// </summary>
        [HttpGet]
        public object GetAllStudents() => throw new NotImplementedException();

        /// <summary>
        /// Returns a specific student by identifier.
        /// A student is an instance of a user.
        /// </summary>
        [HttpGet("{userId}")]
        public object GetStudent(Guid userId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of classes this student is taking.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public object GetClassesForStudent(Guid userId) => throw new NotImplementedException();
    }
}