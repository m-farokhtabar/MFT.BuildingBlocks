using MFT.BuildingBlocks.Domain.Specifications;

namespace MFT.BuildingBlocks.Domain.Exceptions;

public abstract class BrokenRuleDomainException : DomainException
{
    protected BrokenRuleDomainException(IDomainSpecification brokenRule) : base(GetBrokenRuleMessage(brokenRule))
    {
        RuleName = brokenRule.DomainObjectName;
    }

    protected BrokenRuleDomainException(IDomainSpecification brokenRule, Exception innerException) : base(GetBrokenRuleMessage(brokenRule), innerException)
    {        
        RuleName = brokenRule.DomainObjectName;
    }    
    public string RuleName { get; }

    private static string GetBrokenRuleMessage(IDomainSpecification brokenRule)
    {
        if (brokenRule is null)
            throw new ArgumentNullException(nameof(brokenRule),"A broken domain rule must be provided to create this exception.");
        return brokenRule.BrokenRuleMessage;
    }
}
