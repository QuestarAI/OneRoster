namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/teachers")]
    public class TeachersController : BaseController<User>
    {
        public TeachersController(IWorkspace workspace) : base(workspace)
        {
        }

        /// <summary>
        /// Returns the collection of classes this teacher is teaching.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public object GetClassesForTeacher(Guid userId) => throw new NotImplementedException();
    }
}