using Flurl.Http;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.ApiClient.Services
{
    public class AcademicSessionEndpoint : ItemEndpoint<AcademicSession>
    {
        public AcademicSessionEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }
    }
}