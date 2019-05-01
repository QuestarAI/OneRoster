namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class TeacherEndpoint : ItemEndpoint<User>, ITeacherEndpoint
    {
        public TeacherEndpoint(string path) : base(path)
        {
        }

        public IListEndpoint<Class> Classes => new ListEndpoint<Class>($"{Path}/classes");
    }
}