namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class ClassTeachersEndpoint : ListEndpoint<User>
    {
        public ClassTeachersEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}