namespace Questar.OneRoster.Client.Internals
{
    using Implementations;
    using Models;

    public class ClassStudentLineItemsEndpoint : ListEndpoint<LineItem>
    {
        public ClassStudentLineItemsEndpoint(string path) : base(path)
        {
        }
    }
}