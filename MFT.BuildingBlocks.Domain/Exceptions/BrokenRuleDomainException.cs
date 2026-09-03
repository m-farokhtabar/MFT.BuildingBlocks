using MFT.BuildingBlocks.Domain.Primitives;
using MFT.BuildingBlocks.Domain.Specifications;

namespace MFT.BuildingBlocks.Domain.Exceptions;

public abstract class BrokenRuleDomainException : DomainException
{        
    protected BrokenRuleDomainException(string message, IDomainSpecification brokenRule, Type callerType, string callerMethodName) : base(message, callerType, callerMethodName)
    {
        BrokenRule = brokenRule;
    }
    public IDomainSpecification BrokenRule { get; init; }

    public override string ToString()
    {
        return $"RaisedFrom[{RaisedFrom}] | Domain[{BrokenRule.DomainName}] | BrokenRule[{BrokenRule.GetType().FullName}]: {BrokenRule.BrokenRuleMessage}";
    }
}
