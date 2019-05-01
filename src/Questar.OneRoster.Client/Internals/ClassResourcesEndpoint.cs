namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class ClassResourcesEndpoint : ListEndpoint<Resource>
    {
        public ClassResourcesEndpoint(string path) : base(path)
        {
        }
    }
}