namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/students")]
    public class StudentsController : OneRosterController<User>
    {
        public StudentsController(IWorkspace workspace) : base(workspace)
        {
        }

        /// <summary>
        /// Returns the collection of classes this student is taking.
        /// </summary>
        [HttpGet("{userId}/classes")]
        public object GetClassesForStudent(Guid userId) => throw new NotImplementedException();
    }
}