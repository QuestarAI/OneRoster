namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class AcademicSessionsEndpoint : ListEndpoint<AcademicSession>
    {
        public AcademicSessionsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public AcademicSessionEndpoint For(string id) => new AcademicSessionEndpoint(Http, $"{Path}/{id}");
    }
}