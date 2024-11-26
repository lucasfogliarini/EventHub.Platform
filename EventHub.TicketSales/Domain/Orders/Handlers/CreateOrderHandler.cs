using MediatR;
using EventHub.TicketSales.Domain.Orders;

namespace EventHub.TicketSales.Domain.PayrollLoans
{
    public class CreateOrderHandler(
        IOrderRepository orderRepository,
        ITicketRepository ticketRepository,
        IPaymentService paymentService) : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IOrderRepository _orderRepository = orderRepository; // Repositório de pedidos
        private readonly ITicketRepository _ticketRepository = ticketRepository; // Repositório de ingressos
        private readonly IPaymentService _paymentService = paymentService; // Serviço de pagamento (simulação)

        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                EventId = request.EventId,
                TotalPrice = request.TotalPrice,
                PurchaseDate = DateTime.UtcNow,
                PaymentStatus = PaymentStatus.Pending
            };

            await _orderRepository.AddAsync(order);

            // 2. Criar os ingressos associados ao pedido
            var tickets = new List<Ticket>();
            foreach (var ticket in request.Tickets)
            {
                var newTicket = new Ticket
                {
                    Id = Guid.NewGuid(),
                    EventId = request.EventId, // Referência ao evento, mas sem acessar detalhes do evento
                    OrderId = order.Id,
                    TicketType = ticket.TicketTypeId.ToString(), // Usando ID do tipo de ingresso
                    Price = ticket.Price,
                    QRCode = GenerateQRCode() // Função fictícia para gerar o QR Code
                };

                tickets.Add(newTicket);
            }

            await _ticketRepository.AddRangeAsync(tickets);

            // 3. Processar o pagamento (simulação)
            var paymentSuccess = await _paymentService.ProcessPayment(order.TotalPrice);
            if (!paymentSuccess)
            {
                throw new Exception("Payment failed.");
            }

            // 4. Atualizar o status do pedido para "completo"
            order.PaymentStatus = PaymentStatus.Completed;
            await _orderRepository.UpdateAsync(order);

            // 5. Retornar a resposta com o ID do pedido
            return new CreateOrderResponse { OrderId = order.Id };
        }

        // Função fictícia para gerar um QR Code
        private string GenerateQRCode()
        {
            return Guid.NewGuid().ToString(); // Simulação de QR Code gerado
        }
    }

}
