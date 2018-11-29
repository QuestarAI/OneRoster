using System;
using System.Collections.Generic;
using System.Text;

namespace Questar.OneRoster.Transforms
{
    using System.Linq.Expressions;

    interface ITransformProvider
    {
        Transform GetTransform(Type type);
    }

    class TransformProvider
    {
        public Transform GetTransform(Type type)
        {
            throw new NotImplementedException();
        }
    }

    class Transform
    {

    }

    class Transform<T> : Transform
    {
        TransformPart For<TProperty>(Expression<Func<T, TProperty>> projection)
        {
        }
    }

    class TransformPart
    {
        public From
    }

    class TransformPartBuilder
    {
        public From
    }
}
