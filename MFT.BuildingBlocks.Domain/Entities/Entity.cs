namespace MFT.BuildingBlocks.Domain.Entities;

public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
{
    protected Entity() { }

    protected Entity(TId id) => Id = id;

    public TId Id { get; init; } = default!;

    
    public bool Equals(Entity<TId>? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        if (IsTransient() || other.IsTransient()) return false;
        return CompareId(other);
    }
    protected abstract bool CompareId(Entity<TId> other);
    public override bool Equals(object? obj) => Equals(obj as Entity<TId>);

    public override int GetHashCode() => GetCustomHashCode();
    protected abstract int GetCustomHashCode();

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right) => left is null ? right is null : left.Equals(right);
    public static bool operator !=(Entity<TId>? left, Entity<TId>? right) => !(left == right);

    private bool IsTransient() => Id.Equals(default(TId));
}