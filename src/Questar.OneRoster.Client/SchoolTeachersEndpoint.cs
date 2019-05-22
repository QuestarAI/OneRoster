namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class SchoolTeachersEndpoint : ListEndpoint<User>
    {
        public SchoolTeachersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}