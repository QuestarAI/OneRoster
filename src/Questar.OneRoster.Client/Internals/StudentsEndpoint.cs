namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class StudentsEndpoint : ListEndpoint<User>
    {
        public StudentsEndpoint(string path) : base(path)
        {
        }

        public StudentEndpoint For(Guid id) => new StudentEndpoint($"{Path}/{id}") { Http = Http };
    }
}