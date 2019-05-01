namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class TeacherEndpoint : ItemEndpoint<User>
    {
        public TeacherEndpoint(string path) : base(path)
        {
        }

        public TeacherClassesEndpoint Classes => new TeacherClassesEndpoint($"{Path}/classes") { Http = Http };
    }
}