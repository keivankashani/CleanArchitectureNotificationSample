using Sadad.Notification.Application.Repositories;

namespace Sadad.Notification.Application
{
    public interface IUnitOfWork : IDisposable
    {
        IMessageRepository Messages { get; }
        int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
