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
        public LineItemsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<LineItem> Query() => Workspace.LineItems.AsQuery();

        [HttpPut("{SourcedId}")]
        public virtual async Task<ActionResult> Upsert(UpsertRequest<LineItem> request)
        {
            await Workspace.LineItems.UpsertAsync(request.Data);
            await Workspace.SaveAsync();
            return Ok();
        }

        [HttpDelete("{SourcedId}")]
        public virtual async Task<ActionResult> Delete(DeleteRequest request)
        {
            var item = await Workspace.LineItems.AsQuery().WhereHasKey(request.SourcedId).SingleAsync();
            if (item == null)
                return NotFound();
            await Workspace.LineItems.DeleteAsync(item);
            await Workspace.SaveAsync();
            return Ok();
        }
    }
}