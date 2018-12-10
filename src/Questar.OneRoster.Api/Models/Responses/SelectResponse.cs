namespace Questar.OneRoster.Api.Models.Responses
{
    using Collections;
    using OneRoster.Models.Errors;

    public class SelectResponse : Response<IPage>
    {
        public SelectResponse(StatusInfoList statuses = null) : base(statuses)
        {
        }
    }
}