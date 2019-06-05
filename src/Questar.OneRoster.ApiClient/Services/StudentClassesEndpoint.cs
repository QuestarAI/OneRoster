using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class StudentClassesEndpoint : ListEndpoint<Class>
    {
        public StudentClassesEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}