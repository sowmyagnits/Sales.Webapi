using System.Web.Http;
using Order.Business.DataContract;
using Order.Business.Interface;

namespace Product.Webapi.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        //
        // GET: /Product/

        private IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [Route("api/Get")]
        public IHttpActionResult Get(int productId)
        {
            return Ok(_productBusiness.GetProduct(productId));
        }

        [Route("api/GetAll")]
        public IHttpActionResult GetAll()
        {
            return Ok(_productBusiness.GetAll());
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]ProductContract productContract)
        {
            return Ok(_productBusiness.AddProduct(productContract));
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]ProductContract productContract)
        {
            return Ok(_productBusiness.UpdateProduct(productContract));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_productBusiness.DeleteProduct(id));
        }
    }
}