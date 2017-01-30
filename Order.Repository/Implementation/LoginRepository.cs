using Order.Repository.DomainModel;
using Order.Repository.Infrastructure;
using Order.Repository.Interface;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Order.Repository.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public LoginRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Member> FindByUserNameOrEmail(Member user)
        {
            using (var cnn = _connectionFactory.GetConnection())
            {
               
                var param = new DynamicParameters();
                param.Add("@emailtovalidate", user.Email);
                param.Add("@passwordtovalidate", user.PasswordHash);

                var objUser = await cnn.QuerySingleOrDefaultAsync<Member>("GetUser", param: param, commandType: CommandType.StoredProcedure);
                return objUser;
            }
        }

        public async Task<Member> GetRolesByUserId(Member user)
        {
            using (var cnn = _connectionFactory.GetConnection())
            {                
                var param = new DynamicParameters();
                param.Add("@memberid", user.Id);

                var userRole = await cnn.QuerySingleOrDefaultAsync<List<Role>>("GetMemberRoles", param: param, commandType: CommandType.StoredProcedure);
                user.Roles = userRole;
                return user;
            }
        }
    }
}