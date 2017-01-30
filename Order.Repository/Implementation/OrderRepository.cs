using Order.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Order.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<ORDER> GetAll()
        {
            using (var _db = new SiriusIQEntities2())
            {
                return _db.ORDERs.ToList();
            }
        }

        public ORDER GetOrder(int orderId)
        {
            using (var _db = new SiriusIQEntities2())
            {
                return _db.ORDERs.ToList().FirstOrDefault(p => p.ORDERID == orderId);
            }
        }

        public bool AddOrder(ORDER orderBusiness)
        {
            using (var _db = new SiriusIQEntities2())
            {
                _db.ORDERs.Add(orderBusiness);
                int state = _db.SaveChanges();
                return state == 0 ? false : true;
            }
        }

        public bool UpdateOrder(ORDER order)
        {
            using (var _db = new SiriusIQEntities2())
            {
                _db.Entry(order);
                int state = _db.SaveChanges();
                return state == 0 ? false : true;
            }
        }

        public bool DeleteOrder(int orderId)
        {
            using (var _db = new SiriusIQEntities2())
            {
                _db.ORDERs.Remove(new ORDER { ORDERID = orderId });
                int state = _db.SaveChanges();
                return state == 0 ? false : true;
            }
        }
    }
}