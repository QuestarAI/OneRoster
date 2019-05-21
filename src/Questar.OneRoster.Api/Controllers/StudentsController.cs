namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/students")]
    public class StudentsController : BaseController<User>
    {
        public StudentsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<User> Query() => Workspace.Students.AsQuery();

        /// <summary>
        /// Returns the collection of classes this student is taking.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public Task<ActionResult> GetClassesForStudent(string userId) => throw new NotImplementedException();
    }
}