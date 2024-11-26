using EventHub.TicketSales.Domain.Events;
using EventHub.TicketSales.Domain.Orders;
using EventHub.TicketSales.Domain.Tickets;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EventHub.TicketSales.Infrastructure;

public class TicketSalesDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var thisAssembly = Assembly.GetExecutingAssembly();
        modelBuilder.ApplyConfigurationsFromAssembly(thisAssembly);
    }
}
