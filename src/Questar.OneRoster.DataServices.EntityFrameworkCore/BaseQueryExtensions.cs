namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    using AutoMapper.Extensions.ExpressionMapping.Impl;
    using Models;

    public static class BaseQueryExtensions
    {
        public static BaseQuery<T> ToBaseQuery<T>(this ISourceInjectedQueryable<T> source)
            where T : Base =>
            new BaseQuery<T>(source);
    }
}