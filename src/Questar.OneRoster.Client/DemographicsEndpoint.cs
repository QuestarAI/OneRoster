namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class DemographicsEndpoint : ItemEndpoint<Demographics>
    {
        public DemographicsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}