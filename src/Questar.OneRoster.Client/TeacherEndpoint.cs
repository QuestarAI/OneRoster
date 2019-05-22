namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class TeacherEndpoint : ItemEndpoint<User>
    {
        public TeacherEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public TeacherClassesEndpoint Classes => new TeacherClassesEndpoint(Http, $"{Path}/classes");
    }
}