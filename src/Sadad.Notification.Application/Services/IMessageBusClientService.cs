namespace Sadad.Notification.Application.Services
{
    public interface IMessageBusClientService
    {
        void Publish(string message, string routeKey);
    }
}
