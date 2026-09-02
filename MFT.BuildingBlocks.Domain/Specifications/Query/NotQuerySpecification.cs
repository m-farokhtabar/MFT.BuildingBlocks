using MFT.BuildingBlocks.Domain.Primitives;
using System.Linq.Expressions;

namespace MFT.BuildingBlocks.Domain.Specifications.Query;

internal sealed class NotQuerySpecification<T> : QuerySpecification<T>
    where T : IDomainObject
{
    private readonly IQuerySpecification<T> wrapped;

    public NotQuerySpecification(IQuerySpecification<T> wrapped)
    {
        this.wrapped = wrapped;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var expr = wrapped.ToExpression();
        var param = expr.Parameters[0];
        var body = Expression.Not(expr.Body);
        return Expression.Lambda<Func<T, bool>>(body, param);
    }
}
