using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Query;
using Cadastro.Core.Repositories.Query.Base;
using Cadastro.Infrastructure.Data;
using Dapper;

namespace Cadastro.Infrastructure.Repositories
{
    public class ClienteQueryRepository : IQueryRepository<Cliente>, IClienteQueryRepository
    {
        private readonly IDbConector _db;


        public ClienteQueryRepository(IDbConector db)
        {
            _db = db;
        }

        public async Task<IReadOnlyList<Cliente>> GetAllAsync()
        {
            using var connection = _db.CreateConnection();

            connection.Open();
            var result = (await connection.QueryAsync<Cliente>("SELECT Nome, Email, IdGuid FROM Cliente")).ToList();

            return result;
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            using var connection = _db.CreateConnection();

            var parameters = new DynamicParameters();

            parameters.Add("@IdGuid", id);

            connection.Open();
            var result = await connection.QueryFirstOrDefaultAsync<Cliente>("SELECT Nome, Email, IdGuid FROM Cliente WHERE IdGuid = @IdGuid", parameters);

            return result;
        }

        public Task<Cliente> GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
