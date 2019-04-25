namespace Questar.OneRoster.Client
{
    using System;
    using Models;

    public interface IDemographicsEndpoint : IListEndpoint<Demographics>
    {
        IItemEndpoint<Demographics> For(Guid id);
    }
}