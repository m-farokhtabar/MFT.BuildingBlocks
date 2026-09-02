using MFT.BuildingBlocks.Domain.Events;
using MFT.BuildingBlocks.Domain.ValueObjects;

namespace MFT.BuildingBlocks.Domain.Entities;

public abstract class AggregateRoot<TId> : Entity<TId> where TId : EntityId
{
    protected AggregateRoot() { }
    protected AggregateRoot(TId id) : base(id) { }

    private readonly List<IDomainEvent> domainEvents = [];
    public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent) => domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => domainEvents.Clear();

    protected override bool CompareId(Entity<TId> other) => Id.Equals(other.Id);
    protected override int GetCustomHashCode() => HashCode.Combine(GetType(), Id);
}
