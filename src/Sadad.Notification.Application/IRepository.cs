namespace Sadad.Notification.Application
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity? GetById(Guid id);
        void Add(TEntity entity);
    }
}
