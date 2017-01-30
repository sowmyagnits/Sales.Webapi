using System.Threading.Tasks;

namespace Order.Repository.Interface
{
    public interface ILoginRepository
    {
        Task<Member> FindByUserNameOrEmail(Member user);

        Task<Member> GetRolesByUserId(Member user);
    }
}