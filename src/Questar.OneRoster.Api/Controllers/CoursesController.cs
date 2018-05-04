namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/courses")]
    public class CoursesController : Controller
    {
        /// <summary>
        /// Return collection of courses.
        /// </summary>
        [HttpGet]
        public object GetAllCourses() => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of classes that are teaching this course.
        /// </summary>
        [HttpGet("{courseId}/classes")]
        public object GetClassesForCourse(Guid courseId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of resources associated to this course.
        /// </summary>
        [HttpGet("{courseId}/resources")]
        public object GetResourcesForCourse(Guid courseId) => throw new NotImplementedException();

        /// <summary>
        /// Return specific course.
        /// </summary>
        [HttpGet("{courseId}")]
        public object GetCourse(Guid courseId) => throw new NotImplementedException();
    }
}