using System.Net;
using FastEndpoints;
using Order.Api.Repositories;

namespace Order.Api.Features.Order.CreateOrder
{
    public class Endpoint : Endpoint<CreateOrderRequest, CreateOrderResponse, CreateOrderMapper>
    {
        public override void Configure()
        {
            Verbs(Http.POST);
            Post("/order");
            AllowAnonymous();
            Description(x => x
                    .Accepts<CreateOrderRequest>("application/json+custom")
                    .Produces<CreateOrderResponse>(200, "application/json+custom")
                    .Produces<ErrorResponse>(400, "application/json+problem")
                    .ProducesProblem(403),
                clearDefaults: true);
        }

        private IOrderRepository Repository { get; init; }

        public override async Task HandleAsync(CreateOrderRequest req, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(req.OrderNumber))
            {
                AddError(r => r.OrderNumber, "Order number is required!");
            }

            ThrowIfAnyErrors();

            var order = Map.ToEntity(req);
            var createdOrder = Repository.CreateOrder(Map.ToEntity(req));
            if (createdOrder != null)
            {
                await SendAsync(Map.FromEntity(order), (int)HttpStatusCode.Created, cancellation: ct);
                return;
            }

            await SendAsync(new CreateOrderResponse(), (int)HttpStatusCode.NotFound, cancellation: ct);
        }
    }
}
