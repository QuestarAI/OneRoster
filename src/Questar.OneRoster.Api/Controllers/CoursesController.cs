namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/courses")]
    public class CoursesController : Controller
    {
        /// <summary>
        /// Returns the collection of courses.
        /// </summary>
        [HttpGet]
        public object GetAllCourses() => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of classes teaching this course.
        /// </summary>
        [HttpGet("{courseId}/classes")]
        public object GetClassesForCourse(Guid courseId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of resources associated with this course.
        /// </summary>
        [HttpGet("{courseId}/resources")]
        public object GetResourcesForCourse(Guid courseId) => throw new NotImplementedException();

        /// <summary>
        /// Returns a specific course by identifier.
        /// </summary>
        [HttpGet("{courseId}")]
        public object GetCourse(Guid courseId) => throw new NotImplementedException();
    }
}