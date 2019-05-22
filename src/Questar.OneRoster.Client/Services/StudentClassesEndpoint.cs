namespace Questar.OneRoster.Client.Services
{
    using Flurl.Http;
    using Models;

    public class StudentClassesEndpoint : ListEndpoint<Class>
    {
        public StudentClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}