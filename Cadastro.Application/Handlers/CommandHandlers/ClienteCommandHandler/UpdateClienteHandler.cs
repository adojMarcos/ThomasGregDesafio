using Cadastro.Application.Command.ClienteCommand;
using Cadastro.Application.Mapper;
using Cadastro.Application.Response;
using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Command;
using Cadastro.Core.Repositories.Query;
using MediatR;

namespace Cadastro.Application.Handlers.CommandHandlers.ClienteCommandHandler
{
    public class UpdateClienteHandler : IRequestHandler<UpdateClienteCommand, ClienteResponse>
    {
        private readonly IClienteCommandRepository _commandRepository;
        private readonly IClienteQueryRepository _queryRepository;

        public UpdateClienteHandler(IClienteCommandRepository commandRepository, IClienteQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }
        public async Task<ClienteResponse> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = CustomMapper.Mapper.Map<Cliente>(request) ?? throw new ApplicationException("There is a problem in mapper");
            try
            {
                await _commandRepository.UpdateAsync(customerEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedCustomer = await _queryRepository.GetByIdAsync(request.IdGuid);
            var customerResponse = CustomMapper.Mapper.Map<ClienteResponse>(modifiedCustomer);

            return customerResponse;
        }
    }
}
