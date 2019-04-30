namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class CategoriesEndpoint : ListEndpoint<Category>, ICategoriesEndpoint
    {
        public CategoriesEndpoint(string host, string path) : base(host, path)
        {
        }

        public IEditEndpoint<Category> For(Guid id) => throw new NotImplementedException();
    }
}