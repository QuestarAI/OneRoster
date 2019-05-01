namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class CategoriesEndpoint : ListEndpoint<Category>, ICategoriesEndpoint
    {
        public CategoriesEndpoint(string path) : base(path)
        {
        }

        public IEditEndpoint<Category> For(Guid id) => new EditEndpoint<Category>($"{Path}/{id}");
    }
}