namespace MFT.BuildingBlocks.Domain.Events;

public abstract record DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; init; }
    public DateTimeOffset OccurredOn { get; init; }
}
