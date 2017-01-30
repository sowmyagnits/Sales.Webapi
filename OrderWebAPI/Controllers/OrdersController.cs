using System.Web.Http;
using Order.Business.DataContract;
using Order.Business.Interface;

namespace Order.Webapi.Controllers
{
    [Authorize]
    public class OrdersController : ApiController
    {
        private IOrderBusiness _orderBusiness;

        public OrdersController(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }

        [Route("api/Get")]
        public IHttpActionResult Get(int orderId)
        {
            return Ok(_orderBusiness.GetOrder(orderId));
        }

        [Route("api/GetAll")]
        public IHttpActionResult GetAll()
        {
            return Ok(_orderBusiness.GetAll());
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]OrderContract orderContract)
        {
            return Ok(_orderBusiness.AddOrder(orderContract));
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]OrderContract orderContract)
        {
            return Ok(_orderBusiness.UpdateOrder(orderContract));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_orderBusiness.DeleteOrder(id));
        }
    }
}