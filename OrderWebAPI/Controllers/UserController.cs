using Order.Business.DataContract;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace OrderWebAPI.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [Route("api/User/GetUserInfo")]
        public IHttpActionResult GetUserInfo()
        {
            var identity = User.Identity as ClaimsIdentity;
            var user = new UserDataContract
            {
                UserName = identity.Name
            };
            int userId = 0;
            int.TryParse(identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value, out userId);
            user.UserId = userId;
            return Ok(user);
        }
    }
}