namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/classes")]
    public class ClassesController : BaseController<Class>
    {
        public ClassesController(IWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "Classes",
            Singular = "Class"
        })
        {
        }


        /// <summary>
        /// Returns the collection of line items (columns) in the gradebook for this class.
        /// </summary>
        [HttpGet("{classId}/lineItems")]
        public object GetLineItemsForClass(string classId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of results (assessed grades) for this specific line item (column) for this class.
        /// </summary>
        [HttpGet("{classId}/lineItems/{lineItemId}/results")]
        public object GetResultsForLineItemForClass(string classId, string lineItemId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of resources associated to this class.
        /// </summary>
        [HttpGet("{classId}/resources")]
        public object GetResourcesForClass(string classId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of results (assessed grades) for this class.
        /// </summary>
        [HttpGet("{classId}/results")]
        public object GetResultsForClass(string classId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of students who are taking this class.
        /// </summary>
        [HttpGet("{classId}/students")]
        public object GetStudentsForClass(string classId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of results (assessed grades) for this specific student attending this class.
        /// </summary>
        [HttpGet("{classId}/students/{studentId}/results")]
        public object GetResultsForStudentForClass(string classId, string studentId) => throw new NotImplementedException();

        /// <summary>
        /// Returns the collection of teachers who are teaching this class.
        /// </summary>
        [HttpGet("{classId}/teachers")]
        public object GetTeachersForClass(string classId) => throw new NotImplementedException();
    }
}