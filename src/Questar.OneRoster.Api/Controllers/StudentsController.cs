using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.Api.Models;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;
using Questar.OneRoster.Payloads;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/students")]
    public class StudentsController : BaseController<User>
    {
        public StudentsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<User> Query()
        {
            return Workspace.Students.AsQuery();
        }

        /// <summary>
        ///     Returns the collection of classes this student is taking.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public Task<ActionResult<Payload<dynamic[]>>> GetClassesForStudent(string userId, SelectParams @params)
        {
            return Select(() => Workspace.Students.GetClassesForStudent(userId), @params);
        }
    }
}