using Models;

namespace Interfaces
{
    public interface IOrder : ILifeTime
    {
        string sendOrder(Order order);

    }
}