namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/teachers")]
    public class TeachersController : Controller
    {
        /// <summary>
        /// Return collection of teachers. A Teacher is an instance of a User.
        /// </summary>
        [HttpGet]
        public object GetAllTeachers() => throw new NotImplementedException();

        /// <summary>
        /// Return specific teacher.
        /// </summary>
        [HttpGet("{userId}")]
        public object GetTeacher(Guid userId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of classes that this teacher is teaching.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public object GetClassesForTeacher(Guid userId) => throw new NotImplementedException();
    }
}