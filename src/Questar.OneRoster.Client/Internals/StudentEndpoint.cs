namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class StudentEndpoint : ItemEndpoint<User>
    {
        public StudentEndpoint(string path) : base(path)
        {
        }

        public StudentClassesEndpoint Classes => new StudentClassesEndpoint($"{Path}/classes") { Http = Http };
    }
}