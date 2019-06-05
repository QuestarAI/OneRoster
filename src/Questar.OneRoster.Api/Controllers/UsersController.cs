using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.Api.Models;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;
using Questar.OneRoster.Payloads;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/users")]
    public class UsersController : BaseController<User>
    {
        public UsersController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<User> Query()
        {
            return Workspace.Users.AsQuery();
        }

        /// <summary>
        ///     Returns the collection of classes enrolled by this user.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public Task<ActionResult<Payload<dynamic[]>>> GetClassesForUser(string userId, SelectParams @params)
        {
            return Select(() => Workspace.Users.GetClassesForUser(userId), @params);
        }
    }
}