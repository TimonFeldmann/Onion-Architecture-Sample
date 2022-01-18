
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Domain.Generic
{
    public abstract class EventEntity
    {
        public EventEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public List<INotification> DomainEvents { get; protected set; } = new List<INotification>();
        public List<INotification> IntegrationEvents { get; protected set; } = new List<INotification>();

        protected void AddDomainEvent(INotification domainEvent)
        {
            DomainEvents.Add(domainEvent);
        } 

        protected void AddIntegrationEvent(INotification integrationEvent)
        {
            IntegrationEvents.Add(integrationEvent);
        }
    }
}
