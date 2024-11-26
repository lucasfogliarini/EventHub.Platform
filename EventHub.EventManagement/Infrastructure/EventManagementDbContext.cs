using EventHub.EventManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EventHub.EventManagement.Infrastructure;

public class EventManagementDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var thisAssembly = Assembly.GetExecutingAssembly();
        modelBuilder.ApplyConfigurationsFromAssembly(thisAssembly);
    }
}
