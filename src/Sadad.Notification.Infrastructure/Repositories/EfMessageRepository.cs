using Sadad.Notification.Application.Repositories;
using Sadad.Notification.Domain.Model;
using Sadad.Notification.Infrastructure.Persistant;

namespace Sadad.Notification.Infrastructure.Repositories
{
    public class EfMessageRepository : EfRepository<Message>, IMessageRepository
    {
        public EfMessageRepository(NotificationDbContext notificationDbContext)
            : base(notificationDbContext)
        {
        }

        public void MarkAsSent(Guid id)
        {
            var getMessage = Context.Messages.Find(id);

            if (getMessage is not null)
            {
                getMessage.SetAsSent();
                Context.Update(getMessage);
            }
        }
    }
}
