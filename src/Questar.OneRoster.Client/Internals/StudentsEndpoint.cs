namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class StudentsEndpoint : ListEndpoint<User>, IStudentsEndpoint
    {
        public StudentsEndpoint(string path) : base(path)
        {
        }

        public IStudentEndpoint For(Guid id) => new StudentEndpoint($"{Path}/{id}");
    }
}