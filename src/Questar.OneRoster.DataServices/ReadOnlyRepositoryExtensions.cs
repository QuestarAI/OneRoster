namespace Questar.OneRoster.DataServices
{
    using Models;

    public static class ReadOnlyRepositoryExtensions
    {
        public static ReadOnlyRepository<T> ToReadOnly<T>(this IRepository<T> repository)
            where T : Base =>
            new ReadOnlyRepository<T>(repository);
    }
}