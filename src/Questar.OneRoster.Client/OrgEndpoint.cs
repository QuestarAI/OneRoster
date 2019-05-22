namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class OrgEndpoint : ItemEndpoint<Org>
    {
        public OrgEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}