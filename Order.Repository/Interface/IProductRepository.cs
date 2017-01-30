using System.Collections.Generic;

namespace Order.Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<PRODUCT> GetAll();

        PRODUCT GetProduct(int productId);

        bool AddProduct(PRODUCT product);

        bool DeleteProduct(int productId);

        bool UpdateProduct(PRODUCT product);
    }
}