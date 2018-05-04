namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/students")]
    public class StudentsController : Controller
    {
        /// <summary>
        /// Return collection of students. A Student is an instance of a User.
        /// </summary>
        public object GetAllStudents() => throw new NotImplementedException();

        /// <summary>
        /// Return specific student. A Student is an instance of a User.
        /// </summary>
        public object GetStudent(Guid userId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of classes that this student is taking.
        /// </summary>
        public object GetClassesForStudent(Guid userId) => throw new NotImplementedException();
    }
}