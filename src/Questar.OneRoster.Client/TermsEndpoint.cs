namespace Questar.OneRoster.Client
{
    using System;
    using Flurl.Http;
    using Infrastructure;
    using Models;

    public class TermsEndpoint : ListEndpoint<AcademicSession>
    {
        public TermsEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public TermEndpoint For(Guid id) => new TermEndpoint(Http, $"{Path}/{id}");
    }
}