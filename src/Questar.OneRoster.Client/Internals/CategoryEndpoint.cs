namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class CategoryEndpoint : EditEndpoint<Category>
    {
        public CategoryEndpoint(string path) : base(path)
        {
        }
    }
}