namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models.Requests;
    using Models.Responses;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/lineItems")]
    public class LineItemsController : BaseController<LineItem>
    {
        public LineItemsController(IWorkspace workspace) : base(workspace)
        {
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<UpsertResponse<LineItem>>> Upsert(UpsertRequest<LineItem> request) => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<DeleteResponse<LineItem>>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}