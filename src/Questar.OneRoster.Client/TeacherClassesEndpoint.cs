namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class TeacherClassesEndpoint : ListEndpoint<Class>
    {
        public TeacherClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}