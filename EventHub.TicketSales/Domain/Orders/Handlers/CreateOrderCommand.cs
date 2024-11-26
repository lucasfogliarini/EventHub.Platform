using MediatR;

namespace EventHub.TicketSales.Domain.PayrollLoans
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public int UserId { get; set; }
        public Guid EventId { get; set; }
        public List<OrderTicket> Tickets { get; set; } = new();
        public decimal TotalPrice { get; set; }
    }

    public record OrderTicketDto(Guid TicketTypeId, decimal Price);
}
