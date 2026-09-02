using MFT.BuildingBlocks.Domain.Primitives;
using System.Linq.Expressions;

namespace MFT.BuildingBlocks.Domain.Specifications.Query
{
    internal sealed class AndQuerySpecification<T> : QuerySpecification<T>
        where T : IDomainObject
    {
        private readonly IQuerySpecification<T> left;
        private readonly IQuerySpecification<T> right;

        public AndQuerySpecification(IQuerySpecification<T> left, IQuerySpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override Expression<Func<T, bool>> ToExpression()
            => ExpressionCombiner.Combine(left.ToExpression(), right.ToExpression(), Expression.AndAlso);
    }
}
