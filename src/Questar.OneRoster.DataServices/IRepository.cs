namespace Questar.OneRoster.DataServices
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