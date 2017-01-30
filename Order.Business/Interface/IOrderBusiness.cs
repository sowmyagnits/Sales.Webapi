using Order.Business.DataContract;
using System.Collections.Generic;

namespace Order.Business.Interface
{
    public interface IOrderBusiness
    {
        IEnumerable<OrderContract> GetAll();

        OrderContract GetOrder(int orderId);

        bool AddOrder(OrderContract orderContract);

        bool DeleteOrder(int orderId);

        bool UpdateOrder(OrderContract orderContract);
    }
}