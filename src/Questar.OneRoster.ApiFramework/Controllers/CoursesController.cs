namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/courses")]
    public class CoursesController : OneRosterController<Course>
    {
        public CoursesController(IWorkspace workspace) : base(workspace)
        {
        }

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
    }
}