namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("ims/oneroster/v1p1/lineItems")]
    public class LineItemsController : Controller
    {
        /// <summary>
        /// Returns the collection of line items.
        /// </summary>
        [HttpGet]
        public object GetAllLineItems() => throw new NotImplementedException();

        /// <summary>
        /// Marks a specific line item as deleted by identifier.
        /// An immediate GET will result in HTTP 404 code.
        /// </summary>
        [HttpDelete("{lineItemId}")]
        public object DeleteLineItem(Guid lineItemId) => throw new NotImplementedException();

        /// <summary>
        /// Returns a specific line item by identifier.
        /// </summary>
        [HttpGet("{lineItemId}")]
        public object GetLineItem(Guid lineItemId) => throw new NotImplementedException();

        /// <summary>
        /// Creates or replaces a line item by identifier.
        /// </summary>
        [HttpPut("{lineItemId}")]
        public object PutLineItem(Guid lineItemId) => throw new NotImplementedException();
    }
}