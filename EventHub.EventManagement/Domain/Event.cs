namespace EventHub.EventManagement.Domain
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public bool IsOnline { get; set; }
        public string? AccessLink { get; set; }
        public int Capacity { get; set; }
        public List<TicketType> TicketTypes { get; set; } = new();
        public List<Coupon> Coupons { get; set; } = new();
    }
}
