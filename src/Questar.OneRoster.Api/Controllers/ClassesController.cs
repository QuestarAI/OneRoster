namespace Questar.OneRoster.Api.Controllers
{
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/classes")]
    public class ClassesController : BaseController<Class>
    {
        public ClassesController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Class> Query() => Workspace.Classes.AsQuery();

        /// <summary>
        /// Returns the collection of line items (columns) in the gradebook for this class.
        /// </summary>
        [HttpGet("{classId}/lineItems")]
        public Task<ActionResult<dynamic>> GetLineItemsForClass(string classId, SelectRequest request)
            => Select(() => Workspace.Classes.GetLineItemsForClass(classId), request);

        /// <summary>
        /// Returns the collection of results (assessed grades) for this specific line item (column) for this class.
        /// </summary>
        [HttpGet("{classId}/lineItems/{lineItemId}/results")]
        public Task<ActionResult<dynamic>> GetResultsForLineItemForClass(string classId, string lineItemId, SelectRequest request)
            => Select(() => Workspace.Classes.GetResultsForLineItemForClass(classId, lineItemId), request);

        /// <summary>
        /// Returns the collection of resources associated to this class.
        /// </summary>
        [HttpGet("{classId}/resources")]
        public Task<ActionResult<dynamic>> GetResourcesForClass(string classId, SelectRequest request)
            => Select(() => Workspace.Classes.GetResourcesForClass(classId), request);

        /// <summary>
        /// Returns the collection of results (assessed grades) for this class.
        /// </summary>
        [HttpGet("{classId}/results")]
        public Task<ActionResult<dynamic>> GetResultsForClass(string classId, SelectRequest request)
            => Select(() => Workspace.Classes.GetResultsForClass(classId), request);

        /// <summary>
        /// Returns the collection of students who are taking this class.
        /// </summary>
        [HttpGet("{classId}/students")]
        public Task<ActionResult<dynamic>> GetStudentsForClass(string classId, SelectRequest request)
            => Select(() => Workspace.Classes.GetStudentsForClass(classId), request);

        /// <summary>
        /// Returns the collection of results (assessed grades) for this specific student attending this class.
        /// </summary>
        [HttpGet("{classId}/students/{studentId}/results")]
        public Task<ActionResult<dynamic>> GetResultsForStudentForClass(string classId, string studentId, SelectRequest request)
            => Select(() => Workspace.Classes.GetResultsForStudentForClass(classId, studentId), request);

        /// <summary>
        /// Returns the collection of teachers who are teaching this class.
        /// </summary>
        [HttpGet("{classId}/teachers")]
        public Task<ActionResult<dynamic>> GetTeachersForClass(string classId, SelectRequest request)
            => Select(() => Workspace.Classes.GetTeachersForClass(classId), request);
    }
}