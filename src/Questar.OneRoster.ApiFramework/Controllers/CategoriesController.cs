namespace Questar.OneRoster.ApiFramework.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models.Requests;
    using Models.Responses;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/categories")]
    public class CategoriesController : OneRosterController<Category>
    {
        public CategoriesController(IWorkspace workspace) : base(workspace)
        {
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<UpsertResponse<Category>>> Upsert(UpsertRequest<Category> request) => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<DeleteResponse<Category>>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}