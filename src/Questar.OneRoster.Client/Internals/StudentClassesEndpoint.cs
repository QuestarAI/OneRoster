namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class StudentClassesEndpoint : ListEndpoint<Class>
    {
        public StudentClassesEndpoint(string path) : base(path)
        {
        }
    }
}