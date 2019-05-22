namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ResultEndpoint : EditItemEndpoint<Result>
    {
        public ResultEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}