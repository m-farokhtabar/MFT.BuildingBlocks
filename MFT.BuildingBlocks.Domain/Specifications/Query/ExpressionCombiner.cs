using System.Linq.Expressions;

namespace MFT.BuildingBlocks.Domain.Specifications.Query;

internal static class ExpressionCombiner
{
    public static Expression<Func<T, bool>> Combine<T>(
        Expression<Func<T, bool>> left,
        Expression<Func<T, bool>> right,
        Func<Expression, Expression, Expression> merge)
    {
        var param = Expression.Parameter(typeof(T));

        var leftBody = ReplaceParameter(left.Body, left.Parameters[0], param);
        var rightBody = ReplaceParameter(right.Body, right.Parameters[0], param);

        var combined = merge(leftBody, rightBody);
        return Expression.Lambda<Func<T, bool>>(combined, param);
    }

    private static Expression ReplaceParameter(Expression body, ParameterExpression oldParam, ParameterExpression newParam)
        => new ParameterReplacer(oldParam, newParam).Visit(body);

    private sealed class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression oldParam;
        private readonly ParameterExpression newParam;

        public ParameterReplacer(ParameterExpression oldParam, ParameterExpression newParam)
        {
            this.oldParam = oldParam;
            this.newParam = newParam;
        }

        protected override Expression VisitParameter(ParameterExpression node)
            => node == oldParam ? newParam : base.VisitParameter(node);
    }
}
