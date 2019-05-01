namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class ClassStudentsEndpoint : ListEndpoint<User>
    {
        public ClassStudentsEndpoint(string path) : base(path)
        {
        }

        public ClassStudentLineItemsEndpoint ResultsFor(Guid id) => new ClassStudentLineItemsEndpoint($"{Path}/{id}/lineItems") { Http = Http };
    }
}