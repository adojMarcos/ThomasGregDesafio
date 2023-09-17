using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Cadastro.Infrastructure.Data
{
    public interface IDbConector
    {
        public IDbConnection CreateConnection();
    };

    public class DbConnector : IDbConector
    {
        private readonly IConfiguration _configuration;

        public DbConnector(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            string _conectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(_conectionString);
        }
    }
}
