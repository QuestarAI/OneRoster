namespace Questar.OneRoster.Api.Controllers
{
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/courses")]
    public class CoursesController : BaseController<Course>
    {
        public CoursesController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Course> Query() => Workspace.Courses.AsQuery();

        /// <summary>
        /// Returns the collection of classes teaching this course.
        /// </summary>
        [HttpGet("{courseId}/classes")]
        public Task<ActionResult<dynamic>> GetClassesForCourse(string courseId, SelectRequest request)
            => Select(() => Workspace.Courses.GetClassesForCourse(courseId), request);

        /// <summary>
        /// Returns the collection of resources associated with this course.
        /// </summary>
        [HttpGet("{courseId}/resources")]
        public Task<ActionResult<dynamic>> GetResourcesForCourse(string courseId, SelectRequest request)
            => Select(() => Workspace.Courses.GetResourcesForCourse(courseId), request);
    }
}