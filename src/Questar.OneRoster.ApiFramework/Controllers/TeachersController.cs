namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Route("ims/oneroster/v1p1/teachers")]
    public class TeachersController : OneRosterControllerDeprecated
    {
        /// <summary>
        /// Returns the collection of teachers.
        /// A teacher is an instance of a user.
        /// </summary>
        [HttpGet]
        public object GetAllTeachers() => throw new NotImplementedException();

        /// <summary>
        /// Returns a specific teacher by identifier.
        /// A teacher is an instance of a user.
        /// </summary>
        [HttpGet("{userId}")]
        public object GetTeacher(Guid userId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of classes this teacher is teaching.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public object GetClassesForTeacher(Guid userId) => throw new NotImplementedException();
    }
}