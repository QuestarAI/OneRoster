namespace Questar.OneRoster.Data.Services
{
    using System;
    using System.Collections.Generic;

    public abstract class Query : IQuery
    {
        IQuery IQuery.Fields(IEnumerable<string> fields) => Fields(fields);

        protected IQuery Fields(IEnumerable<string> fields) => throw new NotImplementedException();
    }
}