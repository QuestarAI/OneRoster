namespace Questar.OneRoster.Api.Models.Responses
{
    using OneRoster.Models.Errors;

    public class DeleteResponse<T> : Response<T>
    {
        public DeleteResponse(StatusInfoList statuses = null) : base(statuses)
        {
        }
    }
}