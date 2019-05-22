namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class SchoolClassStudentsEndpoint : ListEndpoint<User>
    {
        public SchoolClassStudentsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}