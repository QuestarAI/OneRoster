namespace Questar.OneRoster.ApiFramework.Models.Responses
{
    using OneRoster.Models.Errors;

    public class UpsertResponse<T> : Response<T>
    {
        public UpsertResponse(StatusInfoList statuses = null) : base(statuses)
        {
        }
    }
}