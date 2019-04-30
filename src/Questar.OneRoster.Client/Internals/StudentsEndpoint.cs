namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class StudentsEndpoint : ListEndpoint<User>, IStudentsEndpoint
    {
        public StudentsEndpoint(string host, string path) : base(host, path)
        {
        }

        public IStudentEndpoint For(Guid id) => throw new NotImplementedException();
    }
}