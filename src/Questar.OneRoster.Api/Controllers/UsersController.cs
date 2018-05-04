namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/users")]
    public class UsersController : Controller
    {
        /// <summary>
        /// Returns the collection of users.
        /// </summary>
        [HttpGet]
        public object GetAllUsers() => throw new NotImplementedException();

        /// <summary>
        /// Returns a specific user by identifier.
        /// </summary>
        [HttpGet("{userId}")]
        public object GetUser(Guid userId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of classes enrolled by this user.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public object GetClassesForUser(Guid userId) => throw new NotImplementedException();
    }
}