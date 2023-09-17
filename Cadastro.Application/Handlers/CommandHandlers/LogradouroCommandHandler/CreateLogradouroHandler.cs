using Cadastro.Application.Command.LogradouroCommand;
using Cadastro.Application.Mapper;
using Cadastro.Application.Response;
using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Command;
using Cadastro.Core.Repositories.Query;
using MediatR;

namespace Cadastro.Application.Handlers.CommandHandlers.LogradouroCommandHandler
{
    public class CreateLogradouroHandler : IRequestHandler<CreateLogradouroCommand, LogradouroResponse>
    {
        ILogradouroCommandRepository _commandRepository;
        ILogradouroQueryRepository _queryRepository;

        public CreateLogradouroHandler(ILogradouroCommandRepository commandRepository, ILogradouroQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }
        public async Task<LogradouroResponse> Handle(CreateLogradouroCommand request, CancellationToken cancellationToken)
        {
            var logradouroEntity = CustomMapper.Mapper.Map<Logradouro>(request) ?? throw new ApplicationException("There is a problem in mapper");
            await _commandRepository.AddAsync(logradouroEntity);

            return CustomMapper.Mapper.Map<LogradouroResponse>(await _queryRepository.GetByIdAsync(request.IdGuid));

        }

    }
}
