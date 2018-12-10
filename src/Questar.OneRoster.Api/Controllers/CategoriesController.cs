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
        public CategoriesController(IWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "Categories",
            Singular = "Category"
        })
        {
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<dynamic>> Upsert(UpsertRequest<Category> request) => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<dynamic>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}