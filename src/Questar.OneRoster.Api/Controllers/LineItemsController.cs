namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/lineItems")]
    public class LineItemsController : BaseController<LineItem>
    {
        public LineItemsController(IWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "LineItems",
            Singular = "LineItem"
        })
        {
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<dynamic>> Upsert(UpsertRequest<LineItem> request) => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<dynamic>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}