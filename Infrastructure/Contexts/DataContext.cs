using Infrastructure.Entities.ContactFormsEntities;
using Infrastructure.Entities.SubscribersEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<SubscribeEntity> Subscribers { get; set; }

    public DbSet<ContactRequestEntity> ContactRequests { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ContactRequestEntity>()
            .HasOne(x => x.Service)
            .WithMany(x => x.ContactRequests)
            .HasForeignKey(x => x.ServiceId);
    }
}