namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class LineItemEndpoint : EditEndpoint<LineItem>
    {
        public LineItemEndpoint(string path) : base(path)
        {
        }
    }
}