namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/classes")]
    public class ClassesController : BaseController<Class>
    {
        public ClassesController(IOneRosterWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "Classes",
            Singular = "Class"
        })
        {
        }

        protected override IQuery<Class> Query() => Workspace.Classes.AsQuery();

            /// <summary>
        /// Returns the collection of line items (columns) in the gradebook for this class.
        /// </summary>
        [HttpGet("{classId}/lineItems")]
        public Task<ActionResult> GetLineItemsForClass(string classId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of results (assessed grades) for this specific line item (column) for this class.
        /// </summary>
        [HttpGet("{classId}/lineItems/{lineItemId}/results")]
        public Task<ActionResult> GetResultsForLineItemForClass(string classId, string lineItemId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of resources associated to this class.
        /// </summary>
        [HttpGet("{classId}/resources")]
        public Task<ActionResult> GetResourcesForClass(string classId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of results (assessed grades) for this class.
        /// </summary>
        [HttpGet("{classId}/results")]
        public Task<ActionResult> GetResultsForClass(string classId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of students who are taking this class.
        /// </summary>
        [HttpGet("{classId}/students")]
        public Task<ActionResult> GetStudentsForClass(string classId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of results (assessed grades) for this specific student attending this class.
        /// </summary>
        [HttpGet("{classId}/students/{studentId}/results")]
        public Task<ActionResult> GetResultsForStudentForClass(string classId, string studentId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of teachers who are teaching this class.
        /// </summary>
        [HttpGet("{classId}/teachers")]
        public Task<ActionResult> GetTeachersForClass(string classId) => throw new NotImplementedException();
    }
}