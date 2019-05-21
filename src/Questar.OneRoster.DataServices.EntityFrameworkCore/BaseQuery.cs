namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    using AutoMapper.Extensions.ExpressionMapping.Impl;
    using Models;

    public class BaseQuery<T> : SourceInjectedQuery<T>
        where T : Base
    {
        public BaseQuery(ISourceInjectedQueryable<T> source)
            : base(source, @base => @base.SourcedId, (x, y) => (string) x == (string) y)
        {
        }
    }
}