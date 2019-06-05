using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.Api.Models;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;
using Questar.OneRoster.Payloads;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/courses")]
    public class CoursesController : BaseController<Course>
    {
        public CoursesController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Course> Query()
        {
            return Workspace.Courses.AsQuery();
        }

        /// <summary>
        ///     Returns the collection of classes teaching this course.
        /// </summary>
        [HttpGet("{courseId}/classes")]
        public Task<ActionResult<Payload<dynamic[]>>> GetClassesForCourse(string courseId, SelectParams @params)
        {
            return Select(() => Workspace.Courses.GetClassesForCourse(courseId), @params);
        }

        /// <summary>
        ///     Returns the collection of resources associated with this course.
        /// </summary>
        [HttpGet("{courseId}/resources")]
        public Task<ActionResult<Payload<dynamic[]>>> GetResourcesForCourse(string courseId, SelectParams @params)
        {
            return Select(() => Workspace.Courses.GetResourcesForCourse(courseId), @params);
        }
    }
}