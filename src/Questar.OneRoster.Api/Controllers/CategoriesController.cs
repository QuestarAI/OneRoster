using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questar.OneRoster.Api.Models;
using Questar.OneRoster.DataServices;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.Api.Controllers
{
    [Route("ims/oneroster/v1p1/categories")]
    public class CategoriesController : BaseController<Category>
    {
        public CategoriesController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Category> Query()
        {
            return Workspace.Categories.AsQuery();
        }

        [HttpPut("{SourcedId}")]
        public virtual async Task<ActionResult> Upsert(UpsertParams<Category> @params)
        {
            await Workspace.Categories.UpsertAsync(@params.Data);
            await Workspace.SaveAsync();
            return Ok();
        }

        [HttpDelete("{SourcedId}")]
        public virtual async Task<ActionResult> Delete(DeleteParams @params)
        {
            var category = await Workspace.Categories.AsQuery().WhereHasSourcedId(@params.SourcedId).SingleAsync();
            if (category == null)
                return NotFound();
            await Workspace.Categories.DeleteAsync(category);
            await Workspace.SaveAsync();
            return Ok();
        }
    }
}