namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
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