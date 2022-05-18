namespace Order.Api.Features.Order.CreateOrder
{
    public class CreateOrderRequest
    {
        public string OrderNumber { get; set; }
        public string MarketId { get; set; }
        public string StoreId { get; set; }
        public string Currency { get; set; }
    }

    public class CreateOrderResponse
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }
        public string MarketId { get; set; }
        public string StoreId { get; set; }
        public string Currency { get; set; }
    }
}
