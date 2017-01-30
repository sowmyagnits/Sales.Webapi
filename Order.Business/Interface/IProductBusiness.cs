using Order.Business.DataContract;
using System.Collections.Generic;

namespace Order.Business.Interface
{
    public interface IProductBusiness
    {
        IEnumerable<ProductContract> GetAll();

        ProductContract GetProduct(int productId);

        bool AddProduct(ProductContract product);

        bool DeleteProduct(int productId);

        bool UpdateProduct(ProductContract product);
    }
}