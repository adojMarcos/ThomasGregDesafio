using Cadastro.Core.Entities;

namespace Cadastro.Core.Repositories.Command
{
    public interface IAuthRepository
    {
        Task<Login> Auth(Login user);

    }
}
