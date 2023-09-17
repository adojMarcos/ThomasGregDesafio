using Cadastro.Application.Command.ClienteCommand;
using Cadastro.Application.Mapper;
using Cadastro.Application.Response;
using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Command;
using Cadastro.Core.Repositories.Query;
using MediatR;

namespace Cadastro.Application.Handlers.CommandHandlers.ClienteCommandHandler
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteCommand, ClienteResponse>
    {
        IClienteCommandRepository _commandRepository;
        IClienteQueryRepository _queryRepository;

        public CreateClienteHandler(IClienteCommandRepository commandRepository, IClienteQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }
        public async Task<ClienteResponse> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var clientEntity = CustomMapper.Mapper.Map<Cliente>(request) ?? throw new ApplicationException("There is a problem in mapper");
            await _commandRepository.AddAsync(clientEntity);

            return CustomMapper.Mapper.Map<ClienteResponse>(await _queryRepository.GetByIdAsync(request.IdGuid));

        }
    }
}
