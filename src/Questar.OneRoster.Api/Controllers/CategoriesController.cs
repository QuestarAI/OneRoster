namespace Questar.OneRoster.Api.Controllers
{
    using System;
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

        [HttpPut("{id}")]
        public virtual Task<ActionResult> Upsert(UpsertRequest<Category> request) => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public virtual Task<ActionResult> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}