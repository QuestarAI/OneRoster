namespace Questar.OneRoster.Client.Infrastructure
{
    using System;
    using System.Threading.Tasks;
    using Flurl.Http;

    public class EditItemEndpoint<T> : ItemEndpoint<T>, IEditItemEndpoint<T>
    {
        public EditItemEndpoint(IFlurlClient http, string path) : base(http, path)
        {
        }

        public Task InsertAsync(T entity) =>
            throw new NotImplementedException();

        public Task UpdateAsync(T entity) =>
            throw new NotImplementedException();

        public Task DeleteAsync() =>
            throw new NotImplementedException();
    }
}