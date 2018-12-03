namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models.Requests;
    using Models.Responses;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/lineItems")]
    public class LineItemsController : OneRosterController<LineItem>
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