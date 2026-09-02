using MFT.BuildingBlocks.Domain.Primitives;
using System.Linq.Expressions;

namespace MFT.BuildingBlocks.Domain.Specifications.Query
{
    public interface IQuerySpecification<T> : ISpecification<T> where T : IDomainObject
    {        
        Expression<Func<T, bool>> ToExpression();

        IQuerySpecification<T> And(IQuerySpecification<T> other);
        IQuerySpecification<T> Or(IQuerySpecification<T> other);
        IQuerySpecification<T> Not();
    }
}
