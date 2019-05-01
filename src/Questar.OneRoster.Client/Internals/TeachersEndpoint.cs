namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class TeachersEndpoint : ListEndpoint<User>, ITeachersEndpoint
    {
        public TeachersEndpoint(string path) : base(path)
        {
        }

        public ITeacherEndpoint For(Guid id) => new TeacherEndpoint($"{Path}/{id}");
    }
}