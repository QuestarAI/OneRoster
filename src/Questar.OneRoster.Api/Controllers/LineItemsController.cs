using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.Api.Models;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/lineItems")]
    public class LineItemsController : BaseController<LineItem>
    {
        public LineItemsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<LineItem> Query()
        {
            return Workspace.LineItems.AsQuery();
        }

        [HttpPut("{SourcedId}")]
        public virtual async Task<ActionResult> Upsert(UpsertParams<LineItem> @params)
        {
            await Workspace.LineItems.UpsertAsync(@params.Data);
            await Workspace.SaveAsync();
            return Ok();
        }

        [HttpDelete("{SourcedId}")]
        public virtual async Task<ActionResult> Delete(DeleteParams @params)
        {
            var item = await Workspace.LineItems.AsQuery().WhereHasSourcedId(@params.SourcedId).SingleAsync();
            if (item == null)
                return NotFound();
            await Workspace.LineItems.DeleteAsync(item);
            await Workspace.SaveAsync();
            return Ok();
        }
    }
}