using Order.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Order.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<PRODUCT> GetAll()
        {
            using (var _db = new SiriusIQEntities2())
            {
                return _db.PRODUCTs.ToList();
            }
        }

        public PRODUCT GetProduct(int productId)
        {
            using (var _db = new SiriusIQEntities2())
            {
                return _db.PRODUCTs.ToList().FirstOrDefault(p => p.PRODUCTID == productId);
            }
        }

        public bool AddProduct(PRODUCT product)
        {
            using (var _db = new SiriusIQEntities2())
            {
                _db.PRODUCTs.Add(product);
                int state = _db.SaveChanges();
                return state == 0 ? false : true;
            }
        }

        public bool UpdateProduct(PRODUCT product)
        {
            using (var _db = new SiriusIQEntities2())
            {
                _db.Entry(product);
                int state = _db.SaveChanges();
                return state == 0 ? false : true;
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var _db = new SiriusIQEntities2())
            {
                _db.PRODUCTs.Remove(new PRODUCT { PRODUCTID = productId });
                int state = _db.SaveChanges();
                return state == 0 ? false : true;
            }
        }
    }
}