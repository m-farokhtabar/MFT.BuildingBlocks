namespace MFT.BuildingBlocks.Domain.ValueObjects;

public abstract class EntityId : ValueObject
{
}
public abstract class EntityId<TValue> : EntityId where TValue : notnull
{    
    protected EntityId(TValue value) => Value = value ?? throw new ArgumentNullException(nameof(value),$"The value for {GetType().Name} cannot be null.");

    public TValue Value { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString()!;

    public static implicit operator TValue(EntityId<TValue> entityId) => entityId.Value;
}