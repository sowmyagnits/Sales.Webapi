using System.Collections.Generic;
using Order.Business.DataContract;
using Order.Business.DataContract.DataContractMapper;
using Order.Repository.Interface;
using Order.Business.Interface;

namespace Business.Implementation
{
    public class OrderBusiness : IOrderBusiness
    {
        private IOrderRepository _orderrepository;
        private IMapper _mapper;

        public OrderBusiness(IOrderRepository orderrepository, IMapper mapper)
        {
            _orderrepository = orderrepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderContract> GetAll()
        {
            var orders = _orderrepository.GetAll();
            var orderContract = _mapper.GetOrderContractList(orders);
            return orderContract;
        }

        public OrderContract GetOrder(int id)
        {
            var order = _orderrepository.GetOrder(id);
            var orderContract = _mapper.GetOrder(order);
            return orderContract;
        }

        public bool AddOrder(OrderContract orderContract)
        {
            var order = _mapper.GetOrderFromOrderContract(orderContract);
            var state = _orderrepository.AddOrder(order);
            return state;
        }

        public bool UpdateOrder(OrderContract orderContract)
        {
            var order = _mapper.GetOrderFromOrderContract(orderContract);
            var state = _orderrepository.UpdateOrder(order);
            return state;
        }

        public bool DeleteOrder(int ordid)
        {
            var state = _orderrepository.DeleteOrder(ordid);
            return state;
        }
    }
}