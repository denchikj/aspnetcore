namespace Minimal.WebApi;

using Microsoft.EntityFrameworkCore;
using Minimal.WebApi.Meetup;

public class DatabaseContext : DbContext
{
    public DbSet<MeetupEntity> Meetups { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
}

