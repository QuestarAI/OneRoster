namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class SchoolClassTeachersEndpoint : ListEndpoint<User>
    {
        public SchoolClassTeachersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}