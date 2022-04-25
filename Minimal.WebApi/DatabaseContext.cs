namespace Minimal.WebApi;

using Microsoft.EntityFrameworkCore;
using Minimal.WebApi.Features.Meetup.Entities;
using Minimal.WebApi.Features.User.Entities;
using Minimal.WebApi.Meetup;
using Minimal.WebApi.User;
using System.Reflection;

public class DatabaseContext : DbContext
{
    public DbSet<MeetupEntity> Meetups => Set<MeetupEntity>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}

