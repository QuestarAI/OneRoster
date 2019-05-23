namespace Questar.OneRoster.Api.Controllers
{
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;
    using Payloads;

    [Route("ims/oneroster/v1p1/users")]
    public class UsersController : BaseController<User>
    {
        public UsersController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<User> Query() =>
            Workspace.Users.AsQuery();

        /// <summary>
        /// Returns the collection of classes enrolled by this user.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public Task<ActionResult<Payload<dynamic[]>>> GetClassesForUser(string userId, SelectParams @params) =>
            Select(() => Workspace.Users.GetClassesForUser(userId), @params);
    }
}