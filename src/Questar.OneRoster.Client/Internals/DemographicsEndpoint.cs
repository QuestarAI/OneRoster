namespace Questar.OneRoster.Client.Internals
{
    using System;
    using Implementations;
    using Models;

    public class DemographicsEndpoint : ListEndpoint<Demographics>, IDemographicsEndpoint
    {
        public DemographicsEndpoint(string path) : base(path)
        {
        }

        public IItemEndpoint<Demographics> For(Guid id) => new ItemEndpoint<Demographics>($"{Path}/{id}");
    }
}