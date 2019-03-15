namespace Questar.OneRoster.Collections
{
    using System.Collections;

    public interface IPage
    {
        int Index { get; }
        int Size { get; }
        int Count { get; }
        IEnumerable Items { get; }
    }
}