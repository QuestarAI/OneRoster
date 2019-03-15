namespace Questar.OneRoster.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/results")]
    public class ResultsController : BaseController<Result>
    {
        public ResultsController(IWorkspace workspace) : base(workspace, new BaseControllerOptions
        {
            Plural = "Results",
            Singular = "Result"
        })
        {
        }

        [HttpPut("{id}")]
        public virtual Task<ActionResult<dynamic>> Upsert(UpsertRequest<Result> request) => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public virtual Task<ActionResult<dynamic>> Delete(DeleteRequest request) => throw new NotImplementedException();
    }
}