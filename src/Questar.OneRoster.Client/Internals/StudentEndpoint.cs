namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class StudentEndpoint : ItemEndpoint<User>, IStudentEndpoint
    {
        public StudentEndpoint(string host, string path) : base(host, path)
        {
        }

        public IListEndpoint<Class> Classes { get; }
    }
}