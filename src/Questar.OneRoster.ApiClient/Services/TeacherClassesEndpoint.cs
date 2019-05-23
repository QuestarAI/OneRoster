namespace Questar.OneRoster.ApiClient.Services
{
    using Flurl.Http;
    using Models;

    public class TeacherClassesEndpoint : ListEndpoint<Class>
    {
        public TeacherClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}