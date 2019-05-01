namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class TeacherClassesEndpoint : ListEndpoint<Class>
    {
        public TeacherClassesEndpoint(string path) : base(path)
        {
        }
    }
}