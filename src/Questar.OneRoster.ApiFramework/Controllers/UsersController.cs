namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/users")]
    public class UsersController : BaseController<User>
    {
        public UsersController(IWorkspace workspace) : base(workspace)
        {
        }

        /// <summary>
        /// Returns the collection of classes enrolled by this user.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public object GetClassesForUser(Guid userId) => throw new NotImplementedException();
    }
}