namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class TermsEndpoint : ListEndpoint<AcademicSession>, ITermsEndpoint
    {
        public TermsEndpoint(string path) : base(path)
        {
        }

        public ITermEndpoint For(Guid id) => new TermEndpoint($"{Path}/{id}");
    }
}