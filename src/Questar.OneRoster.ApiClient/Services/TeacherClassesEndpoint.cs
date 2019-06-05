using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class TeacherClassesEndpoint : ListEndpoint<Class>
    {
        public TeacherClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}