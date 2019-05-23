namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class ResultEndpoint : EditItemEndpoint<Result>
    {
        public ResultEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}