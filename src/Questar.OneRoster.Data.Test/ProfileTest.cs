namespace Questar.OneRoster.Data.Test
{
    using System;
    using System.Linq.Expressions;
    using AutoMapper;
    using OneRoster.Expressions;
    using Xunit;

    public abstract class ProfileTest<TSource, TTarget>
    {
        protected ProfileTest(IMapper mapper) => Mapper = mapper;
 
        protected IMapper Mapper { get; }

        protected void CanMap<TSourceProperty, TTargetProperty>(Expression<Func<TSource, TSourceProperty>> source, Expression<Func<TTarget, TTargetProperty>> target)
        {
            Assert.True(ExpressionComparer.AreEqual(source, Mapper.Map<Expression<Func<TSource, TSourceProperty>>>(target)));
            Assert.True(ExpressionComparer.AreEqual(target, Mapper.Map<Expression<Func<TTarget, TTargetProperty>>>(source)));
        }
    }
}