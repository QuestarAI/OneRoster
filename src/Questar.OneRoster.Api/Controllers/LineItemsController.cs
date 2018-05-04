namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/lineItems")]
    public class LineItemsController : Controller
    {
        /// <summary>
        /// Return collection of LineItems.
        /// </summary>
        public object GetAllLineItems() => throw new NotImplementedException();

        /// <summary>
        /// Enable the associated SourcedId to be marked as deleted. An immediate read will result in 404 code.
        /// </summary>
        public object DeleteLineItem(Guid lineItemId) => throw new NotImplementedException();

        /// <summary>
        /// Return specific LineItem.
        /// </summary>
        public object GetLineItem(Guid lineItemId) => throw new NotImplementedException();

        /// <summary>
        /// To create a new LineItem record or to replace one that already exists.
        /// </summary>
        public object PutLineItem(Guid lineItemId) => throw new NotImplementedException();
    }
}