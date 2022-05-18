namespace Order.Api.Features.Order.GetAllOrders
{
    public record OrderResponse
    {
        public OrderResponse()
        { }

        public OrderResponse(List<Models.Order> orders)
        {
            Orders = orders;
        }

        public List<Models.Order> Orders { get; set; }
    }
}
