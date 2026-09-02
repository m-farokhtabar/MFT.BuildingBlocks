using MFT.BuildingBlocks.Domain.Primitives;
using MFT.BuildingBlocks.Domain.Specifications;
using System.Runtime.CompilerServices;

namespace MFT.BuildingBlocks.Domain.Exceptions;

public abstract class BrokenRuleException<T> : DomainException where T : IDomainObject
{        
    protected BrokenRuleException(string message, IDomainSpecification<T> brokenRule, Type callerType, string callerMethodName) : base(message, callerType, callerMethodName)
    {
        BrokenRule = brokenRule;            
    }
    public IDomainSpecification<T> BrokenRule { get; init; }

    public override string ToString()
    {
        return $"RaisedFrom[{RaisedFrom}] | BrokenRule[{BrokenRule.GetType().FullName}]: {BrokenRule.BrokenRuleMessage}";
    }
}
