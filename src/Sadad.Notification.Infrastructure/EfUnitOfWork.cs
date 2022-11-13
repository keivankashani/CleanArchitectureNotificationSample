using Sadad.Notification.Application;
using Sadad.Notification.Application.Repositories;
using Sadad.Notification.Infrastructure.Persistant;
using Sadad.Notification.Infrastructure.Repositories;

namespace Sadad.Notification.Infrastructure
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly NotificationDbContext _context;

        public EfUnitOfWork(NotificationDbContext context)
        {
            _context = context;
            Messages = new EfMessageRepository(_context);
        }

        public IMessageRepository Messages { get; private set; }

        public int Commit() => _context.SaveChanges();

        public async Task<int> CommitAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose() => _context.Dispose();
    }
}
