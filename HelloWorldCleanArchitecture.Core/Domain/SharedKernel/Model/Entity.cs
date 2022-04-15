namespace Ftsoft.Domain
{
    public abstract class Entity
    {
        private List<IDomainEvent> _domainEvents;
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        public void AddEvent(IDomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}