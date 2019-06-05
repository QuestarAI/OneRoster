using System;
using System.Threading.Tasks;

namespace Questar.OneRoster.DataServices
{
    public interface IRepository
    {
        Type Type { get; }

        bool IsReadOnly { get; }

        int Count();

        Task<int> CountAsync();

        IQuery AsQuery();
    }
}