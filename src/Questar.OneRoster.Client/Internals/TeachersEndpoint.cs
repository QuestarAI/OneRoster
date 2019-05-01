namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class TeachersEndpoint : ListEndpoint<User>
    {
        public TeachersEndpoint(string path) : base(path)
        {
        }

        public TeacherEndpoint For(Guid id) => new TeacherEndpoint($"{Path}/{id}") { Http = Http };
    }
}