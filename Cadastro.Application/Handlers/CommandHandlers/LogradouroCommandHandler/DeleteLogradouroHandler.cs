using Cadastro.Application.Command.LogradouroCommand;
using Cadastro.Core.Repositories.Command;
using Cadastro.Core.Repositories.Query;
using MediatR;

namespace Cadastro.Application.Handlers.CommandHandlers.LogradouroCommandHandler
{
    public class DeleteLogradouroHandler : IRequestHandler<DeleteLogradouroCommand, String>
    {
        ILogradouroCommandRepository _commandRepository;
        ILogradouroQueryRepository _queryRepository;

        public DeleteLogradouroHandler(ILogradouroCommandRepository commandRepository, ILogradouroQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }
        public async Task<string> Handle(DeleteLogradouroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var logradouroEntity = await _queryRepository.GetByIdAsync(request.IdGuid);

                await _commandRepository.DeleteAsync(logradouroEntity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return $"Logradouro {request.IdGuid} deletado com sucesso!";
        }
    }
}
