using MFT.BuildingBlocks.Application.Specifications;
using System.Linq.Expressions;

public abstract class QuerySpecification<T> : IQuerySpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; protected set; } = _ => true;
    public List<Expression<Func<T, object>>> Includes { get; } = [];
    public Expression<Func<T, object>>? OrderBy { get; protected set; }
    public Expression<Func<T, object>>? OrderByDescending { get; protected set; }
    public int? Skip { get; protected set; }
    public int? Take { get; protected set; }

    protected void AddInclude(Expression<Func<T, object>> includeExpression) => Includes.Add(includeExpression);

    protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression) => OrderBy = orderByExpression;

    protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescExpression) =>
        OrderByDescending = orderByDescExpression;

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }
}

