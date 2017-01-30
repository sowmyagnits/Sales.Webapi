using Order.Business.DataContract;
using Order.Business.Interface;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OrderWebAPI.Tests
{
    public class TestStartupRegUser : Startup
    {
        public override ILoginBusiness LoginBusiness
        {
            get
            {
                var userDatContract = new UserDataContract { UserName = "test", Email = "test@siriusiq.com" };
                var roleResultDataContract = new List<RoleDataContract> { new RoleDataContract { Id = 201, Name = "Supervisor" } };
                var loginbusiness = new Mock<ILoginBusiness>();
                loginbusiness.Setup(m => m.FindByUserNameorEmail(It.IsAny<LoginDataContract>())).ReturnsAsync(userDatContract);
                loginbusiness.Setup(m => m.GetRolesByUserId(It.IsAny<LoginDataContract>())).ReturnsAsync(roleResultDataContract);
                return loginbusiness.Object as ILoginBusiness;
            }
        }
    }

    public class TestStartupNonRegUser : Startup
    {
        public override ILoginBusiness LoginBusiness
        {
            get
            {
                var loginbusiness = new Mock<ILoginBusiness>();
                loginbusiness.Setup(m => m.FindByUserNameorEmail(It.IsAny<LoginDataContract>())).Returns(Task.FromResult<UserDataContract>(null));
                loginbusiness.Setup(m => m.GetRolesByUserId(It.IsAny<LoginDataContract>())).Returns(Task.FromResult<List<RoleDataContract>>(null));
                return loginbusiness.Object as ILoginBusiness;
            }
        }
    }
}