namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class TermClassesEndpoint : ListEndpoint<Class>
    {
        public TermClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}