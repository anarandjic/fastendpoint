namespace Order.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Dictionary<Guid, Models.Order> _orders = new();

        public List<Models.Order> GetAll()
        {
            return _orders.Values.ToList();
        }

        public Models.Order? GetOrderById(Guid id)
        {
            return _orders[id];
        }

        public Models.Order? CreateOrder(Models.Order? order)
        {
            if (order is null)
            {
                return null;
            }

            _orders[order.Id] = order;

            return _orders[order.Id];
        }
    }
}
