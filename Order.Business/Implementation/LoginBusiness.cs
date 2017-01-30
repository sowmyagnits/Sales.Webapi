using Order.Business.DataContract;
using Order.Business.Interface;
using Order.Repository;
using Order.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Business.Implementation
{
    public class LoginBusiness : ILoginBusiness
    {
        private readonly ILoginRepository _loginRepository;

        public LoginBusiness(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<UserDataContract> FindByUserNameorEmail(LoginDataContract logindataContract)
        {
            var user = new Member
            {
                Email = logindataContract.Email,
                PasswordHash = logindataContract.PasswordHash,
            };

            var userResult = await _loginRepository.FindByUserNameOrEmail(user);

            var userDataContract = new UserDataContract
            {
                UserId = userResult.Id,
                UserName = userResult.UserName,
                Email = userResult.Email
            };

            return userDataContract;
        }

        public async Task<List<RoleDataContract>> GetRolesByUserId(LoginDataContract loginDataContract)
        {
            var objUser = new Member { Id = loginDataContract.UserId };

            var userRole = await _loginRepository.GetRolesByUserId(objUser);

            var roleDataContract = userRole.Roles.Select(m => new RoleDataContract { Id = m.Id, Name = m.Name }).ToList();

            return roleDataContract;
        }
    }
}