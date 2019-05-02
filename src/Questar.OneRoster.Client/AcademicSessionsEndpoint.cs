namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class AcademicSessionsEndpoint : ListEndpoint<AcademicSession>
    {
        public AcademicSessionsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public AcademicSessionEndpoint For(Guid id) => new AcademicSessionEndpoint(Http, $"{Path}/{id}");
    }
}