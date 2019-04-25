namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface ICategoriesEndpoint : IListEndpoint<Category>
    {
        IEditEndpoint<Category> For(Guid id);
    }
}