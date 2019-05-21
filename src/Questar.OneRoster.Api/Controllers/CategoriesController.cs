namespace Questar.OneRoster.Api.Controllers
{
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/categories")]
    public class CategoriesController : BaseController<Category>
    {
        public CategoriesController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Category> Query() => Workspace.Categories.AsQuery();

        [HttpPut("{SourcedId}")]
        public virtual async Task<ActionResult> Upsert(UpsertRequest<Category> request)
        {
            await Workspace.Categories.UpsertAsync(request.Data);
            await Workspace.SaveAsync();
            return Ok();
        }

        [HttpDelete("{SourcedId}")]
        public virtual async Task<ActionResult> Delete(DeleteRequest request)
        {
            var category = await Workspace.Categories.AsQuery().WhereHasKey(request.SourcedId).SingleAsync();
            if (category == null)
                return NotFound();
            await Workspace.Categories.DeleteAsync(category);
            await Workspace.SaveAsync();
            return Ok();
        }
    }
}