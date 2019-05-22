namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class TermClassesEndpoint : ListEndpoint<Class>
    {
        public TermClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}