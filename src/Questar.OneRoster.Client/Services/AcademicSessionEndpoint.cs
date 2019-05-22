namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class AcademicSessionEndpoint : ItemEndpoint<AcademicSession>
    {
        public AcademicSessionEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}