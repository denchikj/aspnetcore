namespace Minimal.WebApi;

using Microsoft.EntityFrameworkCore;
using Minimal.WebApi.Meetup;
using Minimal.WebApi.User;

public class DatabaseContext : DbContext
{
    public DbSet<MeetupEntity> Meetups { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
}

