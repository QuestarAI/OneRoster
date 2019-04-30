namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class TermsEndpoint : ListEndpoint<AcademicSession>, ITermsEndpoint
    {
        public TermsEndpoint(string host, string path) : base(host, path)
        {
        }

        public ITermEndpoint For(Guid id) => throw new NotImplementedException();
    }
}