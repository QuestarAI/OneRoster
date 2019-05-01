namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class CategoriesEndpoint : ListEndpoint<Category>
    {
        public CategoriesEndpoint(string path) : base(path)
        {
        }

        public CategoryEndpoint For(Guid id) => new CategoryEndpoint($"{Path}/{id}") { Http = Http };
    }
}