
using MediatR;
using Shopping.Domain.Events;
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
        [NotMapped]
        public List<ICustomNotification> Events { get; protected set; } = new List<ICustomNotification>();

        protected void AddEvent(ICustomNotification domainEvent)
        {
            Events.Add(domainEvent);
        } 
    }
}
