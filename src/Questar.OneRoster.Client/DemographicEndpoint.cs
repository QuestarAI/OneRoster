namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class DemographicEndpoint : ItemEndpoint<Demographics>
    {
        public DemographicEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}