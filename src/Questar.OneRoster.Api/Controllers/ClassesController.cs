namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/classes")]
    public class ClassesController : Controller
    {
        /// <summary>
        /// Return collection of classes.
        /// </summary>
        public object GetAllClasses() => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of line items (Columns) in the gradebook for this class.
        /// </summary>
        public object GetLineItemsForClass(Guid classId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of results (assessed grades), for this specific lineItem (Column) for this class.
        /// </summary>
        public object GetResultsForLineItemForClass(Guid classId, Guid lineItemId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of resources associated to this class.
        /// </summary>
        public object GetResourcesForClass(Guid classId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of results (assessed grades) for this class.
        /// </summary>
        public object GetResultsForClass(Guid classId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of students that are taking this class.
        /// </summary>
        public object GetStudentsForClass(Guid classId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of results (assessed grades), for this specific student, attending this class.
        /// </summary>
        public object GetResultsForStudentForClass(Guid classId, Guid studentId) => throw new NotImplementedException();

        /// <summary>
        /// Return the collection of teachers that are teaching this class.
        /// </summary>
        public object GetTeachersForClass(Guid classId) => throw new NotImplementedException();

        /// <summary>
        /// Return specific class.
        /// </summary>
        public object GetClass(Guid classId) => throw new NotImplementedException();
    }
}