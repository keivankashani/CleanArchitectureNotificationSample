using Microsoft.EntityFrameworkCore;
using Sadad.Notification.Domain.Model;

namespace Sadad.Notification.Infrastructure.Persistant
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
