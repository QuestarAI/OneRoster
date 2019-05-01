namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class AcademicSessionsEndpoint : ListEndpoint<AcademicSession>
    {
        public AcademicSessionsEndpoint(string path) : base(path)
        {
        }

        public AcademicSessionEndpoint For(Guid id) => new AcademicSessionEndpoint($"{Path}/{id}") { Http = Http };
    }
}