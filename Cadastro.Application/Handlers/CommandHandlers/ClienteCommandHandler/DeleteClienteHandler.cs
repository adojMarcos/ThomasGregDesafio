using Cadastro.Application.Command.ClienteCommand;
using Cadastro.Core.Repositories.Command;
using Cadastro.Core.Repositories.Query;
using MediatR;

namespace Cadastro.Application.Handlers.CommandHandlers.ClienteCommandHandler
{
    public class DeleteClienteHandler : IRequestHandler<DeleteClienteCommand, String>
    {
        IClienteCommandRepository _commandRepository;
        IClienteQueryRepository _queryRepository;

        public DeleteClienteHandler(IClienteCommandRepository commandRepository, IClienteQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }
        public async Task<string> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customerEntity = await _queryRepository.GetByIdAsync(request.IdGuid);

                await _commandRepository.DeleteAsync(customerEntity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return $"Cliente {request.IdGuid} deletado com sucesso!";
        }
    }
}
