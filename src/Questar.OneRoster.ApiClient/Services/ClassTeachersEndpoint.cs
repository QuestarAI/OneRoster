namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class ClassTeachersEndpoint : ListEndpoint<User>
    {
        public ClassTeachersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}