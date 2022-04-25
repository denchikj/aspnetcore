namespace Minimal.WebApi;

using Microsoft.EntityFrameworkCore;
using Minimal.WebApi.Meetup;
using Minimal.WebApi.User;
using System.Reflection;

public class DatabaseContext : DbContext
{
    public DbSet<MeetupEntity> Meetups { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}

