namespace Questar.OneRoster.ApiFramework.Models.Responses
{
    using OneRoster.Models.Errors;

    public class SingleResponse : Response<object>
    {
        public SingleResponse(StatusInfoList statuses = null) : base(statuses)
        {
        }
    }
}