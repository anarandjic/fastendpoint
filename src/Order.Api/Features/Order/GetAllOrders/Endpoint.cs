using FastEndpoints;
using Order.Api.Repositories;

namespace Order.Api.Features.Order.GetAllOrders
{
    public class Endpoint : EndpointWithoutRequest<OrderResponse>
    {
        public override void Configure()
        {
            Verbs(Http.GET);
            Get("/orders");
            AllowAnonymous();
        }

        private IOrderRepository Repository { get; init; }
        
        public override async Task HandleAsync(CancellationToken ct)
        {
            //alternative for SendAsync()
            //Response = await _data.GetAllOrders();
            var orders = Repository.GetAll();

            await SendAsync(new OrderResponse(orders), cancellation: ct);
        }
    }
}
