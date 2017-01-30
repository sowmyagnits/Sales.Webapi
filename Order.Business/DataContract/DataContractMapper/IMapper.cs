using Order.Repository;
using System.Collections.Generic;

namespace Order.Business.DataContract.DataContractMapper
{
    public interface IMapper
    {
        OrderContract GetOrder(ORDER Order);

        ProductContract GetProductContract(PRODUCT Product);

        ReviewContract GetReviewContract(REVIEW REVIEW);

        IEnumerable<OrderContract> GetOrderContractList(IEnumerable<ORDER> orders);

        IEnumerable<ProductContract> GetProductContractList(IEnumerable<PRODUCT> products);

        ORDER GetOrderFromOrderContract(OrderContract orderContract);

        PRODUCT GetProduct(ProductContract product);
    }
}