namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class ResourceEndpoint : ItemEndpoint<Resource>
    {
        public ResourceEndpoint(string path) : base(path)
        {
        }
    }
}