namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/students")]
    public class StudentsController : BaseController<User>
    {
        public StudentsController(IWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "Users",
            Singular = "User"
        })
        {
        }

        protected override IQuery<User> Query() => base.Query().Where(user => user.Role == RoleType.Teacher);

        /// <summary>
        /// Returns the collection of classes this student is taking.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public object GetClassesForStudent(string userId) => throw new NotImplementedException();
    }
}