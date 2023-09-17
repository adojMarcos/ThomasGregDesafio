using Cadastro.Application.Queries.ClienteQuery;
using Cadastro.Core.Entities;
using MediatR;

namespace Cadastro.Application.Handlers.QueryHandlers.ClienteHandler
{
    public class GetClienteByIdHandler : IRequestHandler<GetClienteByIdQuery, Cliente>
    {
        private readonly IMediator _mediator;

        public GetClienteByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Cliente> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var customers = await _mediator.Send(new GetAllClienteQuery());
            var selectedCustomer = customers.FirstOrDefault(x => x.IdGuid == request.Id);
            return selectedCustomer;
        }
    }
}
