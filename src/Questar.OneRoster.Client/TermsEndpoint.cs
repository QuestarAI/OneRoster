namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class TermsEndpoint : ListEndpoint<AcademicSession>
    {
        public TermsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public TermEndpoint For(string id) =>
            new TermEndpoint(Http, $"{Path}/{id}");
    }
}