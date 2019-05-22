namespace Questar.OneRoster.Client
{
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class StudentClassesEndpoint : ListEndpoint<Class>
    {
        public StudentClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}