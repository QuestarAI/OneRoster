namespace Questar.OneRoster.Data
{
    using System;
    using System.Threading.Tasks;

    public interface IRepository
    {
        Type Type { get; }

        bool IsReadOnly { get; }

        int Count();

        Task<int> CountAsync();

        IQuery AsQuery();
    }
}