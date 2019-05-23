namespace Questar.OneRoster.Api.Controllers
{
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;
    using Payloads;

    [Route("ims/oneroster/v1p1/students")]
    public class StudentsController : BaseController<User>
    {
        public StudentsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<User> Query() =>
            Workspace.Students.AsQuery();

        /// <summary>
        /// Returns the collection of classes this student is taking.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public Task<ActionResult<Payload<dynamic[]>>> GetClassesForStudent(string userId, SelectParams @params) =>
            Select(() => Workspace.Students.GetClassesForStudent(userId), @params);
    }
}