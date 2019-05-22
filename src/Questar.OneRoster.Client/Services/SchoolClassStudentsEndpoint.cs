namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class SchoolClassStudentsEndpoint : ListEndpoint<User>
    {
        public SchoolClassStudentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}