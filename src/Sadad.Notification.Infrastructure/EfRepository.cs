using Microsoft.EntityFrameworkCore;
using Sadad.Notification.Application;
using Sadad.Notification.Infrastructure.Persistant;

namespace Sadad.Notification.Infrastructure
{
    public abstract class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly NotificationDbContext Context;

        private readonly DbSet<TEntity> _dbSet;

        public EfRepository(NotificationDbContext context)
        {
            Context = context;
            _dbSet = Context.Set<TEntity>();
        }
        public TEntity? GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

    }
}
