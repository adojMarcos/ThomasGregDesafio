using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Query;
using Cadastro.Core.Repositories.Query.Base;
using Cadastro.Infrastructure.Data;
using Dapper;

namespace Cadastro.Infrastructure.Repositories
{
    public class LogradouroQueryRepository : IQueryRepository<Logradouro>, ILogradouroQueryRepository
    {
        private readonly IDbConector _db;


        public LogradouroQueryRepository(IDbConector db)
        {
            _db = db;
        }

        public async Task<IReadOnlyList<Logradouro>> GetAllAsync()
        {
            using var connection = _db.CreateConnection();

            connection.Open();
            var result = (await connection.QueryAsync<Logradouro>("SELECT LogradouroNome, IdCliente, IdGuid FROM Logradouro")).ToList();

            return result;
        }

        public async Task<Logradouro> GetByIdAsync(Guid id)
        {
            using var connection = _db.CreateConnection();

            connection.Open();

            var parameters = new DynamicParameters();

            parameters.Add("@IdGuid", id);

            var result = await connection.QueryFirstOrDefaultAsync<Logradouro>("SELECT LogradouroNome, IdCliente, IdGuid FROM Logradouro WHERE IdGuid = @IdGuid", parameters);

            return result;
        }

        public Task<Logradouro> GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
