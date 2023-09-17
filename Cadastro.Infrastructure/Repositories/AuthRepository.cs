using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Command;
using Cadastro.Infrastructure.Data;
using Dapper;
using static Dapper.SqlMapper;

namespace Cadastro.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbConector _db;

        public AuthRepository(IDbConector db)
        {
            _db = db;
        }
        public async Task<Login> Auth(Login u)
        {
            try
            {
                using var connection = _db.CreateConnection();

                connection.Open();

                var parameters = new DynamicParameters();

                parameters.AddDynamicParams(u);

                var result = await connection.QueryFirstOrDefaultAsync<Login>("SELECT Email, Password FROM Login WHERE Email = @Email And Password = @Password ", parameters);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
