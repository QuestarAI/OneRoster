namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/users")]
    public class UsersController : BaseController<User>
    {
        public UsersController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<User> Query() => Workspace.Users.AsQuery();

        /// <summary>
        /// Returns the collection of classes enrolled by this user.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public Task<ActionResult<dynamic>> GetClassesForUser(string userId, SelectRequest request)
            => Select(() => Workspace.Users.GetClassesForUser(userId), request);
    }
}