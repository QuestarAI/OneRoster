namespace Questar.OneRoster.Data.Test
{
    using System;
    using System.Linq.Expressions;
    using AutoMapper;
    using Xunit;

    public abstract class ProfileTest<TSource, TTarget>
    {
        protected ProfileTest(IMapper mapper) => Mapper = mapper;
 
        protected IMapper Mapper { get; }

        protected void CanMap<TSourceProperty, TTargetProperty>(Expression<Func<TSource, TSourceProperty>> expected, Expression<Func<TTarget, TTargetProperty>> target)
            => Assert.True(ExpressionComparer.AreEqual(expected, Mapper.Map<Expression<Func<TSource, TSourceProperty>>>(target)));
    }
}