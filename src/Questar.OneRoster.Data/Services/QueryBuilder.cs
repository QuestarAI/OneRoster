namespace Questar.OneRoster.Data.Services
{
    using System;

    public abstract class QueryBuilder : IQueryBuilder
    {
        IQueryBuilder IQueryBuilder.Fields(string[] fields) => Fields(fields);

        protected IQueryBuilder Fields(string[] fields) => throw new NotImplementedException();
    }
}