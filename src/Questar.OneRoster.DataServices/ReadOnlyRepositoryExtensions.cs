namespace Questar.OneRoster.DataServices
{
    public static class ReadOnlyRepositoryExtensions
    {
        public static ReadOnlyRepository<T> ToReadOnly<T>(this IRepository<T> repository)
            => new ReadOnlyRepository<T>(repository);
    }
}