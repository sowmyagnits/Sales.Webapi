using System.Data;

namespace Order.Repository.Infrastructure
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}