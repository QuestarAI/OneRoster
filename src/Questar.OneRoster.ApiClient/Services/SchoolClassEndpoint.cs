using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class SchoolClassEndpoint : ItemEndpoint<Class>
    {
        public SchoolClassEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public SchoolClassEnrollmentsEndpoint Enrollments => new SchoolClassEnrollmentsEndpoint(Http, $"{Path}/enrollments");
        public SchoolClassStudentsEndpoint Students => new SchoolClassStudentsEndpoint(Http, $"{Path}/students");
        public SchoolClassTeachersEndpoint Teachers => new SchoolClassTeachersEndpoint(Http, $"{Path}/teachers");
    }
}