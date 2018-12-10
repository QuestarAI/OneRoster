namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models.Requests;
    using Models.Responses;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/results")]
    public class ResultsController : BaseController<Result>
    {
        public ResultsController(IWorkspace workspace) : base(workspace)
        {
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<UpsertResponse<Result>>> Upsert(UpsertRequest<Result> request) => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<DeleteResponse<Result>>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}