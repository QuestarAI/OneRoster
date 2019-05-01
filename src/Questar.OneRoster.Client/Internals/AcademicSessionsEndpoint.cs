namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class AcademicSessionsEndpoint : ListEndpoint<AcademicSession>, IAcademicSessionsEndpoint
    {
        public AcademicSessionsEndpoint(string path) : base(path)
        {
        }

        public IItemEndpoint<AcademicSession> For(Guid id) => new ItemEndpoint<AcademicSession>($"{Path}/{id}");
    }
}