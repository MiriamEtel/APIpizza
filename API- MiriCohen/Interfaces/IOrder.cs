using Models;

namespace Interfaces
{
    public interface IOrder : ILifeTime
    {
         string SendOrder(Order order);

    }
}