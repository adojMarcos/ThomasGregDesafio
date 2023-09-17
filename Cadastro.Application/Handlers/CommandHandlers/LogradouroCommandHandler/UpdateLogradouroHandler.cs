using Cadastro.Application.Command.LogradouroCommand;
using Cadastro.Application.Mapper;
using Cadastro.Application.Response;
using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Command;
using Cadastro.Core.Repositories.Query;
using MediatR;

namespace Cadastro.Application.Handlers.CommandHandlers.LogradouroCommandHandler
{
    public class UpdateLogradouroHandler : IRequestHandler<UpdateLogradouroCommand, LogradouroResponse>
    {
        ILogradouroCommandRepository _commandRepository;
        ILogradouroQueryRepository _queryRepository;

        public UpdateLogradouroHandler(ILogradouroCommandRepository commandRepository, ILogradouroQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }
        public async Task<LogradouroResponse> Handle(UpdateLogradouroCommand request, CancellationToken cancellationToken)
        {
            var logradouroEntity = CustomMapper.Mapper.Map<Logradouro>(request) ?? throw new ApplicationException("There is a problem in mapper");
            try
            {
                await _commandRepository.UpdateAsync(logradouroEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedLogradouro = await _queryRepository.GetByIdAsync(request.IdGuid);
            var logradouroResponse = CustomMapper.Mapper.Map<LogradouroResponse>(modifiedLogradouro);

            return logradouroResponse;
        }
    }
}
