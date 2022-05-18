using FastEndpoints;

namespace Order.Api.Features.Order.CreateOrder
{
    public class CreateOrderMapper : Mapper<CreateOrderRequest, CreateOrderResponse, Models.Order>
    {
        public override CreateOrderResponse FromEntity(Models.Order? e)
        {
            if (e is null)
            {
                return new CreateOrderResponse();
            }

            return new CreateOrderResponse
            {
                Id = e.Id,
                Currency = e.Currency,
                MarketId = e.MarketId,
                OrderNumber = e.OrderNumber,
                StoreId = e.StoreId
            };
        }

        public override Models.Order ToEntity(CreateOrderRequest r)
        {
            return new Models.Order
            {
                Currency = r.Currency,
                MarketId = r.MarketId,
                OrderNumber = r.OrderNumber,
                StoreId = r.StoreId
            };
        }
    }
}
