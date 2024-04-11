using Infrastructure.Entities.CoursesEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class CosmosDbContext : DbContext
{
    public CosmosDbContext(DbContextOptions<CosmosDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<CourseEntity> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseEntity>()
            .ToContainer("Courses")
            .HasNoDiscriminator()
            .HasPartitionKey(x => x.Id);



    }
}