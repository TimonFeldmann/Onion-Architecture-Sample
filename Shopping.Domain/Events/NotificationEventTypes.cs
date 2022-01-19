using MediatR;

namespace Shopping.Domain.Events
{
    public enum NotificationEventType
    {
        Domain,
        Integration
    }

    public interface ICustomNotification : INotification
    {
        NotificationEventType NotificationEventType { get; set; }
    }
}
