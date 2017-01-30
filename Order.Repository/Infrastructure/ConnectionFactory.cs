using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Order.Repository.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SiriusIQAppCon"].ConnectionString;
        private readonly string providerName = ConfigurationManager.ConnectionStrings["SiriusIQAppCon"].ProviderName;

        public IDbConnection GetConnection()
        {
                var factory = DbProviderFactories.GetFactory(providerName);
                var conn = factory.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                return conn;
        }
    }
}