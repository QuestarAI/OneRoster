using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.Api.Models;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;
using Questar.OneRoster.Payloads;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/classes")]
    public class ClassesController : BaseController<Class>
    {
        public ClassesController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Class> Query()
        {
            return Workspace.Classes.AsQuery();
        }

        /// <summary>
        ///     Returns the collection of line items (columns) in the gradebook for this class.
        /// </summary>
        [HttpGet("{classId}/lineItems")]
        public Task<ActionResult<Payload<dynamic[]>>> GetLineItemsForClass(string classId, SelectParams @params)
        {
            return Select(() => Workspace.Classes.GetLineItemsForClass(classId), @params);
        }

        /// <summary>
        ///     Returns the collection of results (assessed grades) for this specific line item (column) for this class.
        /// </summary>
        [HttpGet("{classId}/lineItems/{lineItemId}/results")]
        public Task<ActionResult<Payload<dynamic[]>>> GetResultsForLineItemForClass(string classId, string lineItemId, SelectParams @params)
        {
            return Select(() => Workspace.Classes.GetResultsForLineItemForClass(classId, lineItemId), @params);
        }

        /// <summary>
        ///     Returns the collection of resources associated to this class.
        /// </summary>
        [HttpGet("{classId}/resources")]
        public Task<ActionResult<Payload<dynamic[]>>> GetResourcesForClass(string classId, SelectParams @params)
        {
            return Select(() => Workspace.Classes.GetResourcesForClass(classId), @params);
        }

        /// <summary>
        ///     Returns the collection of results (assessed grades) for this class.
        /// </summary>
        [HttpGet("{classId}/results")]
        public Task<ActionResult<Payload<dynamic[]>>> GetResultsForClass(string classId, SelectParams @params)
        {
            return Select(() => Workspace.Classes.GetResultsForClass(classId), @params);
        }

        /// <summary>
        ///     Returns the collection of students who are taking this class.
        /// </summary>
        [HttpGet("{classId}/students")]
        public Task<ActionResult<Payload<dynamic[]>>> GetStudentsForClass(string classId, SelectParams @params)
        {
            return Select(() => Workspace.Classes.GetStudentsForClass(classId), @params);
        }

        /// <summary>
        ///     Returns the collection of results (assessed grades) for this specific student attending this class.
        /// </summary>
        [HttpGet("{classId}/students/{studentId}/results")]
        public Task<ActionResult<Payload<dynamic[]>>> GetResultsForStudentForClass(string classId, string studentId, SelectParams @params)
        {
            return Select(() => Workspace.Classes.GetResultsForStudentForClass(classId, studentId), @params);
        }

        /// <summary>
        ///     Returns the collection of teachers who are teaching this class.
        /// </summary>
        [HttpGet("{classId}/teachers")]
        public Task<ActionResult<Payload<dynamic[]>>> GetTeachersForClass(string classId, SelectParams @params)
        {
            return Select(() => Workspace.Classes.GetTeachersForClass(classId), @params);
        }
    }
}