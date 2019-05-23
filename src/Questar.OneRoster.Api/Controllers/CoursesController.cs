namespace Questar.OneRoster.Api.Controllers
{
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;
    using Payloads;

    [Route("ims/oneroster/v1p1/courses")]
    public class CoursesController : BaseController<Course>
    {
        public CoursesController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Course> Query() =>
            Workspace.Courses.AsQuery();

        /// <summary>
        /// Returns the collection of classes teaching this course.
        /// </summary>
        [HttpGet("{courseId}/classes")]
        public Task<ActionResult<Payload<dynamic[]>>> GetClassesForCourse(string courseId, SelectParams @params) =>
            Select(() => Workspace.Courses.GetClassesForCourse(courseId), @params);

        /// <summary>
        /// Returns the collection of resources associated with this course.
        /// </summary>
        [HttpGet("{courseId}/resources")]
        public Task<ActionResult<Payload<dynamic[]>>> GetResourcesForCourse(string courseId, SelectParams @params) =>
            Select(() => Workspace.Courses.GetResourcesForCourse(courseId), @params);
    }
}