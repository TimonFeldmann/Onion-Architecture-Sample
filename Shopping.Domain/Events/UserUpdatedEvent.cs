using MediatR;
using Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Events
{
    public class UserUpdatedEvent : ICustomNotification
    {
        public NotificationEventType NotificationEventType { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
