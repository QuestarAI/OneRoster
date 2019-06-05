using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices
{
    public static class ReadOnlyRepositoryExtensions
    {
        public static ReadOnlyRepository<T> ToReadOnly<T>(this IRepository<T> repository)
            where T : Base
        {
            return new ReadOnlyRepository<T>(repository);
        }
    }
}