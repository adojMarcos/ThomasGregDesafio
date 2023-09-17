using Cadastro.Application.Queries.LogradouroQuery;
using Cadastro.Core.Entities;
using MediatR;

namespace Cadastro.Application.Handlers.QueryHandlers.LogradouroHandler
{
    public class GetLogradouroByIdHandler : IRequestHandler<GetLogradouroByIdQuery, Logradouro>
    {
        private readonly IMediator _mediator;

        public GetLogradouroByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Logradouro> Handle(GetLogradouroByIdQuery request, CancellationToken cancellationToken)
        {
            var customers = await _mediator.Send(new GetAllLogradouroQuery());
            var selectedCustomer = customers.FirstOrDefault(x => x.IdGuid == request.Id);
            return selectedCustomer;
        }
    }
}
