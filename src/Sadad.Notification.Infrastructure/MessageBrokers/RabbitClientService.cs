using RabbitMQ.Client;
using Sadad.Notification.Application.Services;
using System.Text;

namespace Sadad.Notification.Infrastructure.MessageBrokers
{
    public class RabbitClientService : IMessageBusClientService
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        public RabbitClientService()
        {
            _factory = new ConnectionFactory();
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }
        public void Publish(string message, string routeKey)
        {
            var byteMessage = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish("", routeKey, null, byteMessage);
        }
    }
}
