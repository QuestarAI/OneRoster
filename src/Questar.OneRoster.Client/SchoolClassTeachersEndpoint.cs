namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class SchoolClassTeachersEndpoint : ListEndpoint<User>
    {
        public SchoolClassTeachersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}