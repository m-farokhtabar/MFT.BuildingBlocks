using MFT.BuildingBlocks.Domain.Primitives;
using System.Linq.Expressions;

namespace MFT.BuildingBlocks.Domain.Specifications.Query
{
    public abstract class QuerySpecification<T> : IQuerySpecification<T> where T : IDomainObject
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T candidate) => ToExpression().Compile()(candidate);

        public IQuerySpecification<T> And(IQuerySpecification<T> other) => new AndQuerySpecification<T>(this, RequireQuery(other));

        public IQuerySpecification<T> Or(IQuerySpecification<T> other) => new OrQuerySpecification<T>(this, RequireQuery(other));

        public IQuerySpecification<T> Not() => new NotQuerySpecification<T>(this);

        private static IQuerySpecification<T> RequireQuery(IQuerySpecification<T> other)
        {
            if (other is not IQuerySpecification<T> query)
                throw new InvalidOperationException(
                    $"Cannot combine a query specification with a plain specification. " +
                    $"'{other.GetType().Name}' must implement {nameof(IQuerySpecification<T>)}.");

            return query;
        }
    }
}
