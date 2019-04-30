namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class TeacherEndpoint : ItemEndpoint<User>, ITeacherEndpoint
    {
        public TeacherEndpoint(string host, string path) : base(host, path)
        {
        }

        public IListEndpoint<Class> Classes { get; }
    }
}