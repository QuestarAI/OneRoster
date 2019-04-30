namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class AcademicSessionsEndpoint : ListEndpoint<AcademicSession>, IAcademicSessionsEndpoint
    {
        public AcademicSessionsEndpoint(string host, string path) : base(host, path)
        {
        }

        public IItemEndpoint<AcademicSession> For(Guid id) => throw new NotImplementedException();
    }
}