namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class TeachersEndpoint : ListEndpoint<User>, ITeachersEndpoint
    {
        public TeachersEndpoint(string host, string path) : base(host, path)
        {
        }

        public ITeacherEndpoint For(Guid id) => throw new NotImplementedException();
    }
}