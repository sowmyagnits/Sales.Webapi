using System.Collections.Generic;

namespace Order.Repository.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<ORDER> GetAll();

        ORDER GetOrder(int orderId);

        bool AddOrder(ORDER order);

        bool DeleteOrder(int orderId);

        bool UpdateOrder(ORDER order);
    }
}