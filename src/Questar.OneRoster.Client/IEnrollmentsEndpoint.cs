namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IEnrollmentsEndpoint : IListEndpoint<Enrollment>
    {
        IItemEndpoint<Enrollment> For(Guid id);
    }
}