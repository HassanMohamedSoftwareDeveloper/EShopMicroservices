namespace Ordering.Domain.Abstractions;

public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    #region Fields :

    private readonly List<IDomainEvent> _domainEvents = [];

    #endregion Fields :

    #region PROPS :

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    #endregion PROPS :

    #region Methods :

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] dequeuedEvents = [.. _domainEvents];
        _domainEvents.Clear();
        return dequeuedEvents;
    }

    #endregion Methods :
}