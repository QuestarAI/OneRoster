using AutoMapper.Extensions.ExpressionMapping.Impl;
using Questar.OneRoster.Models;

namespace Questar.OneRoster.DataServices.EntityFrameworkCore
{
    public static class BaseQueryExtensions
    {
        public static BaseQuery<T> ToBaseQuery<T>(this ISourceInjectedQueryable<T> source)
            where T : Base
        {
            return new BaseQuery<T>(source);
        }
    }
}