using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Command;
using Cadastro.Infrastructure.Data;
using Dapper;
using System.Data;

namespace Cadastro.Infrastructure.Repositories
{
    public class ClienteCommandRepository : IClienteCommandRepository
    {
        private readonly IDbConector _db;

        public ClienteCommandRepository(IDbConector db)
        {
            _db = db;
        }
        public async Task AddAsync(Cliente entity)
        {
            try
            {
                using IDbConnection conn = _db.CreateConnection();
                conn.Open();
                var parameters = new DynamicParameters();

                parameters.AddDynamicParams(entity);

                await conn.ExecuteAsync("CreateCliente", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public async Task DeleteAsync(Cliente entity)
        {
            try
            {
                using IDbConnection conn = _db.CreateConnection();
                conn.Open();
                var parameters = new DynamicParameters();

                parameters.Add("@IdGuid", entity.IdGuid);

                await conn.ExecuteAsync("DeleteCliente", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task UpdateAsync(Cliente entity)
        {
            try
            {
                using IDbConnection conn = _db.CreateConnection();
                conn.Open();
                var parameters = new DynamicParameters();

                parameters.AddDynamicParams(entity);

                await conn.ExecuteAsync("UpdateCliente", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
