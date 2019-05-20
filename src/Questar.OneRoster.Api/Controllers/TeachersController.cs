namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/teachers")]
    public class TeachersController : BaseController<User>
    {
        public TeachersController(IOneRosterWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "Users",
            Singular = "User"
        })
        {
        }

        protected override IQuery<User> Query() => Workspace.Teachers.AsQuery();

        /// <summary>
        /// Returns the collection of classes this teacher is teaching.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public Task<ActionResult> GetClassesForTeacher(string userId) => throw new NotImplementedException();
    }
}