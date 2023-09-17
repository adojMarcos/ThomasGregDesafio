using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Query.Base;

namespace Cadastro.Core.Repositories.Query
{
    public interface ILogradouroQueryRepository : IQueryRepository<Logradouro>
    {
        Task<IReadOnlyList<Logradouro>> GetAllAsync();
        Task<Logradouro> GetByIdAsync(Guid id);
        Task<Logradouro> GetCustomerByEmail(string email);
    }
}
