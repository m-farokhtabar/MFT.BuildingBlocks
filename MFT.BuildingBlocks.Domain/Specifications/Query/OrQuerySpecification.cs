using MFT.BuildingBlocks.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MFT.BuildingBlocks.Domain.Specifications.Query
{
    internal sealed class OrQuerySpecification<T> : QuerySpecification<T>
        where T : IDomainObject
    {
        private readonly IQuerySpecification<T> left;
        private readonly IQuerySpecification<T> right;

        public OrQuerySpecification(IQuerySpecification<T> left, IQuerySpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
            => ExpressionCombiner.Combine(left.ToExpression(), right.ToExpression(), Expression.OrElse);
    }
}
