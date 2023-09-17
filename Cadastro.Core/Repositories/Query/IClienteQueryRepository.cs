using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Query.Base;

namespace Cadastro.Core.Repositories.Query
{
    public interface IClienteQueryRepository : IQueryRepository<Cliente>
    {
        Task<IReadOnlyList<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(Guid id);
        Task<Cliente> GetCustomerByEmail(string email);
    }
}
