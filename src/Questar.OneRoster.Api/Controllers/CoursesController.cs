namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/courses")]
    public class CoursesController : BaseController<Course>
    {
        public CoursesController(IOneRosterWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "Courses",
            Singular = "Course"
        })
        {
        }

        protected override IQuery<Course> Query() => Workspace.Courses.AsQuery();

        /// <summary>
        /// Returns the collection of classes teaching this course.
        /// </summary>
        [HttpGet("{courseId}/classes")]
        public Task<ActionResult> GetClassesForCourse(string courseId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of resources associated with this course.
        /// </summary>
        [HttpGet("{courseId}/resources")]
        public Task<ActionResult> GetResourcesForCourse(string courseId) => throw new NotImplementedException();
    }
}