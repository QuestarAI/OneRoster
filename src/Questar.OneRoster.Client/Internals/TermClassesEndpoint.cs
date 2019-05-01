namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class TermClassesEndpoint : ListEndpoint<Class>
    {
        public TermClassesEndpoint(string path) : base(path)
        {
        }
    }
}