namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class StudentEndpoint : ItemEndpoint<User>, IStudentEndpoint
    {
        public StudentEndpoint(string path) : base(path)
        {
        }

        public IListEndpoint<Class> Classes => new ListEndpoint<Class>($"{Path}/classes");
    }
}