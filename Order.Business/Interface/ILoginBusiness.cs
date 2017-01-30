using Order.Business.DataContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.Business.Interface
{
    public interface ILoginBusiness
    {
        Task<UserDataContract> FindByUserNameorEmail(LoginDataContract loginBusinessModel);

        Task<List<RoleDataContract>> GetRolesByUserId(LoginDataContract loginBusinessModel);
    }
}