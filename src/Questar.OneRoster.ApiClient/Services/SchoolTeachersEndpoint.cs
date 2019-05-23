namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class SchoolTeachersEndpoint : ListEndpoint<User>
    {
        public SchoolTeachersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}