using System.Collections.Generic;
using System.Linq;
using Order.Repository;

namespace Order.Business.DataContract.DataContractMapper
{
    public class Mapper : IMapper
    {
        public OrderContract GetOrder(ORDER order)
        {
            var ordercontract = new OrderContract
            {
                ORDERID = order.ORDERID,
                DESCRIPTION = order.DESCRIPTION,
                CREATEDDATE = order.CREATEDDATE,
                ORDERDETAILs = order.ORDERDETAILs.Select(
                x => new OrderDetailsContract
                {
                    ORDERDETAILID = x.ORDERDETAILID,
                    DESCRIPTION = x.DESCRIPTION,
                    CREATEDDATE = x.CREATEDDATE
                }
                ).ToList()
            };

            return ordercontract;
        }

        public ProductContract GetProductContract(PRODUCT PRODUCT)
        {
            var productcontract = new ProductContract
            {
                ProductID = PRODUCT.PRODUCTID,

                CreatedDate = PRODUCT.CREATEDDATE,
                Brand = PRODUCT.Brand,
                REVIEWs = PRODUCT.REVIEWs.Select(
                m => new ReviewContract
                {
                    Comments = m.COMMENTS,
                    CreatedDate = m.CREATEDDATE,
                    ProductReviewID = m.PRODUCTREVIEWID,
                    Ratings = m.RATINGS,
                    ReviewerName = m.REVIEWERNAME,
                    ReviewDate = m.REVIEWDATE
                }
                ).ToList()
            };
            return productcontract;
        }

        public ReviewContract GetReviewContract(REVIEW Review)
        {
            var reviewcontrat = new ReviewContract
            {
                ProductReviewID = Review.PRODUCTREVIEWID,
                ProductID = Review.PRODUCTID,
                Comments = Review.COMMENTS,
                ReviewDate = Review.REVIEWDATE,
                ReviewerName = Review.REVIEWERNAME,
                Ratings = Review.RATINGS,
                CreatedDate = Review.CREATEDDATE,
            };

            return reviewcontrat;
        }

        public IEnumerable<OrderContract> GetOrderContractList(IEnumerable<ORDER> orders)
        {
            var orderContractList = orders.Select(
            x => new OrderContract
            {
                CREATEDDATE = x.CREATEDDATE,
                DESCRIPTION = x.DESCRIPTION,
                ORDERDETAILs = x.ORDERDETAILs.Select(
                m => new OrderDetailsContract
                {
                    ORDERDETAILID = m.ORDERDETAILID,
                    DESCRIPTION = m.DESCRIPTION
                }
                ).ToList(),
                ORDERID = x.ORDERID
            }).ToList();

            return orderContractList;
        }

        public ORDER GetOrderFromOrderContract(OrderContract orderContract)
        {
            var order = new ORDER
            {
                CREATEDDATE = orderContract.CREATEDDATE,
                DESCRIPTION = orderContract.DESCRIPTION,
                ORDERID = orderContract.ORDERID,
                ORDERDETAILs = orderContract.ORDERDETAILs.Select(
                x => new ORDERDETAIL
                {
                    CREATEDDATE = x.CREATEDDATE,
                    DESCRIPTION = x.DESCRIPTION,
                    ORDERDETAILID = x.ORDERDETAILID
                }
                ).ToList()
            };
            return order;
        }

        public IEnumerable<ProductContract> GetProductContractList(IEnumerable<PRODUCT> products)
        {
            var productContractList = products.Select(
            x => new ProductContract
            {
                ProductID = x.PRODUCTID,
                Description = x.Description,
                CreatedDate = x.CREATEDDATE,
                Brand = x.Brand,
                REVIEWs = x.REVIEWs.Select(
                m => new ReviewContract
                {
                    Comments = m.COMMENTS,
                    CreatedDate = m.CREATEDDATE,
                    ProductReviewID = m.PRODUCTREVIEWID,
                    Ratings = m.RATINGS,
                    ReviewerName = m.REVIEWERNAME,
                    ReviewDate = m.REVIEWDATE
                }).ToList()
            }).ToList();

            return productContractList;
        }

        public PRODUCT GetProduct(ProductContract product)
        {
            var productOb = new PRODUCT
            {
                Brand = product.Brand,
                CREATEDDATE = product.CreatedDate,
                Description = product.Description,
                PRODUCTID = product.ProductID,
                REVIEWs = product.REVIEWs.Select(
                x => new REVIEW
                {
                    COMMENTS = x.Comments,
                    CREATEDDATE = x.CreatedDate,
                    PRODUCTREVIEWID = x.ProductReviewID,
                    RATINGS = x.Ratings,
                    REVIEWDATE = x.ReviewDate,
                    REVIEWERNAME = x.ReviewerName
                }
                ).ToList()
            };
            return productOb;
        }
    }
}