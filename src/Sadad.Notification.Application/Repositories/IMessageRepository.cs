using Sadad.Notification.Domain.Model;

namespace Sadad.Notification.Application.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        public void MarkAsSent(Guid magfaId);
    }
}
