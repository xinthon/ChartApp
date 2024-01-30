namespace Modules.Auth.Domain.Primitives;

public abstract class Entity<TIdentity> : IEquatable<Entity<TIdentity>>, IHasDomainEvent where TIdentity : class
{
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    public TIdentity Id { get; private set; }

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public Entity(TIdentity id) { Id = id; }

    public void AddDomainEvent(IDomainEvent domainEvent) { _domainEvents.Add(domainEvent); }

    public bool Equals(Entity<TIdentity>? other)
    {
        if (other is null)
            return false;

        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TIdentity> entity)
            return false;

        return base.Equals(entity);
    }

    public override int GetHashCode() { return base.GetHashCode(); }

    public void ClearDomainEvents() { _domainEvents.Clear(); }

    public static bool operator !=(Entity<TIdentity> left, Entity<TIdentity> right) => !left.Equals(right);

    public static bool operator ==(Entity<TIdentity> left, Entity<TIdentity> right) => left.Equals(right);
}
