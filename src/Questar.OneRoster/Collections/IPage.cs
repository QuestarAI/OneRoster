namespace Questar.OneRoster.Collections
{
    using System.Collections;

    public interface IPage
    {
        int Count { get; }
        IEnumerable Items { get; }
    }
}