namespace Order.Api.Repositories
{
    public interface IOrderRepository
    {
        List<Models.Order> GetAll();
        Models.Order? GetOrderById(Guid id);
        Models.Order? CreateOrder(Models.Order? order);
    }

}
