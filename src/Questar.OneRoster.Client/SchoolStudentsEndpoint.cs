namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class SchoolStudentsEndpoint : ListEndpoint<User>
    {
        public SchoolStudentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}