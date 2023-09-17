using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Command;
using Cadastro.Infrastructure.Data;
using Dapper;
using System.Data;

namespace Cadastro.Infrastructure.Repositories
{
    public class LogradouroCommandRepository : ILogradouroCommandRepository
    {
        private readonly IDbConector _db;

        public LogradouroCommandRepository(IDbConector db)
        {
            _db = db;
        }
        public async Task AddAsync(Logradouro entity)
        {
            try
            {
                using IDbConnection conn = _db.CreateConnection();
                conn.Open();
                var parameters = new DynamicParameters();

                parameters.AddDynamicParams(entity);

                await conn.ExecuteAsync("CreateLogradouro", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task DeleteAsync(Logradouro entity)
        {
            try
            {
                using IDbConnection conn = _db.CreateConnection();
                conn.Open();
                var parameters = new DynamicParameters();

                parameters.Add("@IdGuid", entity.IdGuid);

                await conn.ExecuteAsync("DeleteLogradouro", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task UpdateAsync(Logradouro entity)
        {
            try
            {
                using IDbConnection conn = _db.CreateConnection();
                conn.Open();
                var parameters = new DynamicParameters();

                parameters.AddDynamicParams(entity);

                await conn.ExecuteAsync("UpdateLogradouro", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
