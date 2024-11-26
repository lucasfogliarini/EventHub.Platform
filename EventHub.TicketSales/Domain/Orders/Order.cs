using EventHub.TicketSales.Domain.Tickets;

namespace EventHub.TicketSales.Domain.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public Guid EventId { get; set; }
        public List<Ticket> Tickets { get; set; } = [];
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Canceled,
        Refunded
    }

}
