namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/users")]
    public class UsersController : Controller
    {
        /// <summary>
        /// Return collection of users.
        /// </summary>
        public object GetAllUsers() => throw new NotImplementedException();

        /// <summary>
        /// Return specific user.
        /// </summary>
        public object GetUser(Guid userId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of classes attended by this user.
        /// </summary>
        public object GetClassesForUser(Guid userId) => throw new NotImplementedException();
    }
}