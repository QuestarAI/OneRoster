namespace Questar.OneRoster.ApiFramework.Models.Responses
{
    using OneRoster.Models.Errors;

    public class DeleteResponse<T> : Response<T>
    {
        public DeleteResponse(StatusInfoList statuses = null) : base(statuses)
        {
        }
    }
}