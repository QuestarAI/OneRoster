namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class AcademicSessionEndpoint : ItemEndpoint<AcademicSession>
    {
        public AcademicSessionEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}