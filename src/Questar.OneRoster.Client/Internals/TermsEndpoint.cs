namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class TermsEndpoint : ListEndpoint<AcademicSession>
    {
        public TermsEndpoint(string path) : base(path)
        {
        }

        public TermEndpoint For(Guid id) => new TermEndpoint($"{Path}/{id}") { Http = Http };
    }
}