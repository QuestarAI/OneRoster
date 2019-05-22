namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class SchoolStudentsEndpoint : ListEndpoint<User>
    {
        public SchoolStudentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}