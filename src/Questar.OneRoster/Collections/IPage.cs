using System.Collections;

namespace Questar.OneRoster.Collections
{
    public interface IPage
    {
        int Count { get; }

        IEnumerable Items { get; }
    }
}