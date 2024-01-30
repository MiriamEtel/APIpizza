using Models;

namespace Interfaces
{
    public interface IOrder : ILifeTime
    {
        Task<string> SendOrder(Order order);
        Order? Get();
        void Receipt(Order ordr);
        Task<string> MakePizzaAsync(List<OrderItem> items);
        Task<string> payAsync (Order order);

    }
}