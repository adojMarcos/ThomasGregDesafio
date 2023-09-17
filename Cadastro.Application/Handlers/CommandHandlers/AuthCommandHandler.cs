using Cadastro.Application.Command;
using Cadastro.Application.Mapper;
using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Command;
using MediatR;

namespace Cadastro.Application.Handlers.CommandHandlers
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, Login>
    {
        IAuthRepository _authRepository;

        public AuthCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<Login> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var login = CustomMapper.Mapper.Map<Login>(request) ?? throw new ApplicationException("There is a problem in mapper");
            return await _authRepository.Auth(login);
        }
    }
}
