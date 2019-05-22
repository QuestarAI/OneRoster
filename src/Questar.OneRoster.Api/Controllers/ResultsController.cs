namespace Questar.OneRoster.Api.Controllers
{
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using OneRoster.Models;

    [Route("ims/oneroster/v1p1/results")]
    public class ResultsController : BaseController<Result>
    {
        public ResultsController(IOneRosterWorkspace workspace) : base(workspace)
        {
        }

        protected override IQuery<Result> Query() => Workspace.Results.AsQuery();

        [HttpPut("{SourcedId}")]
        public virtual async Task<ActionResult> Upsert(UpsertParams<Result> @params)
        {
            await Workspace.Results.UpsertAsync(@params.Data);
            await Workspace.SaveAsync();
            return Ok();
        }

        [HttpDelete("{SourcedId}")]
        public virtual async Task<ActionResult> Delete(DeleteParams @params)
        {
            var result = await Workspace.Results.AsQuery().WhereHasSourcedId(@params.SourcedId).SingleAsync();
            if (result == null)
                return NotFound();
            await Workspace.Results.DeleteAsync(result);
            await Workspace.SaveAsync();
            return Ok();
        }
    }
}