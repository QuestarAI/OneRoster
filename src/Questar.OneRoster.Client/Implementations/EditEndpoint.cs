namespace Questar.OneRoster.Client.Implementations
{
    using System;
    using System.Threading.Tasks;

    public class EditEndpoint<T> : ItemEndpoint<T>, IEditEndpoint<T>
    {
        public EditEndpoint(string path) : base(path)
        {
        }

        public Task InsertAsync(T entity) => throw new NotImplementedException();

        public Task UpdateAsync(T entity) => throw new NotImplementedException();

        public Task DeleteAsync() => throw new NotImplementedException();
    }
}