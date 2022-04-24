namespace Minimal.WebApi;

using Microsoft.EntityFrameworkCore;
using Minimal.WebApi.Meetup;

internal class DatabaseContext : DbContext
{
    public DbSet<MeetupEntity> Meetups { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder option) =>
        option.UseNpgsql("Server=localhost;Port=5432;Database=test;User Id=postgres;Password=00000");
}

