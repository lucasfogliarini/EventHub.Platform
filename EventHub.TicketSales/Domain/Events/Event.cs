namespace EventHub.TicketSales.Domain.Events
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
