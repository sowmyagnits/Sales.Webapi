using System.Collections.Generic;
using Order.Business.DataContract;
using Order.Business.DataContract.DataContractMapper;
using Order.Repository.Interface;
using Order.Business.Interface;

namespace Business.Implementation
{
    public class ProductBusiness : IProductBusiness
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductBusiness(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductContract> GetAll()
        {
            var products = _productRepository.GetAll();

            var productcontract = _mapper.GetProductContractList(products);
            return productcontract;
        }

        public ProductContract GetProduct(int productId)
        {
            var product = _productRepository.GetProduct(productId);
            var productcontract = _mapper.GetProductContract(product);
            return productcontract;
        }

        public bool AddProduct(ProductContract productContract)
        {
            var product = _mapper.GetProduct(productContract);
            var state = _productRepository.AddProduct(product);
            return state;
        }

        public bool DeleteProduct(int productId)
        {
            var state = _productRepository.DeleteProduct(productId);
            return state;
        }

        public bool UpdateProduct(ProductContract product)
        {
            var productContract = _mapper.GetProduct(product);
            var state = _productRepository.UpdateProduct(productContract);
            return state;
        }
    }
}