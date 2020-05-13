using System.Collections.Generic;

namespace Ecommerce.Core.DDD
{
    public abstract class AggregateRoot
    {
        public AggregateRoot()
        {
            _events = new List<IEvent>();
        }
        private List<IEvent> _events;

        public IReadOnlyCollection<IEvent> Events => _events?.AsReadOnly();

        protected void Raise(IEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public void ClearAllEvents()
        {
            _events?.Clear();
        }
    }
}
