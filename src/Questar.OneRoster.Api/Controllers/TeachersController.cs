using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.Api.Models;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;
using Questar.OneRoster.Payloads;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/teachers")]
    public class TeachersController : BaseController<User>
    {
        public TeachersController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<User> Query()
        {
            return Workspace.Teachers.AsQuery();
        }

        /// <summary>
        ///     Returns the collection of classes this teacher is teaching.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public Task<ActionResult<Payload<dynamic[]>>> GetClassesForTeacher(string userId, SelectParams @params)
        {
            return Select(() => Workspace.Teachers.GetClassesForTeacher(userId), @params);
        }
    }
}