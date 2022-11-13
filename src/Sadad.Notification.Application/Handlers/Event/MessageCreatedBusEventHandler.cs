using MediatR;
using Newtonsoft.Json;
using Polly;
using Sadad.Notification.Application.Services;
using Sadad.Notification.Domain.Enums;
using Sadad.Notification.Domain.Event;

namespace Sadad.Notification.Application.Handlers.Event
{
    public class MessageCreatedBusEventHandler : INotificationHandler<MessageCreatedEvent>
    {
        private readonly IMessageBusClientService _rabbitClientService;
        public MessageCreatedBusEventHandler(IMessageBusClientService rabbitClientService)
        {
            _rabbitClientService = rabbitClientService;
        }

        public async Task Handle(MessageCreatedEvent notification, CancellationToken cancellationToken)
        {

            var serializedMessage = JsonConvert.SerializeObject(notification);
            var routKey = "";
            if (notification.SmsType == SmsType.Normal)
            {
                routKey = "normal";
            }
            else
            {
                routKey = "immediate";
            }

            Policy.Handle<Exception>().Retry(3, onRetry: (exception, retryCount) =>
            {
                _rabbitClientService.Publish(serializedMessage, routKey);
            });
        }
    }
}
