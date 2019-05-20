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
        public LineItemsController(IOneRosterWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "LineItems",
            Singular = "LineItem"
        })
        {
        }

        protected override IQuery<LineItem> Query() => Workspace.LineItems.AsQuery();

        [HttpPut("{id}")]
        public virtual Task<ActionResult<dynamic>> Upsert(UpsertRequest<LineItem> request) => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public virtual Task<ActionResult<dynamic>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}