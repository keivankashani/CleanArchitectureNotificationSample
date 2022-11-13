using MediatR;
using Sadad.Notification.Domain.Enums;

namespace Sadad.Notification.Domain.Event
{
    public class MessageCreatedEvent : INotification
    {
        public SmsType SmsType { get; set; }
        public string NationalCode { get; private set; }
        public string MessageBody { get; private set; }
        public DateTime? SendDateTime { get; private set; }
    }
}
