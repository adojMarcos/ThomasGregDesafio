using Cadastro.Application.Queries.ClienteQuery;
using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Query;
using MediatR;

namespace Cadastro.Application.Handlers.QueryHandlers.ClienteHandler
{
    public class GetAllClienteHandler : IRequestHandler<GetAllClienteQuery, List<Cliente>>
    {
        private readonly IClienteQueryRepository _customerQueryRepository;

        public GetAllClienteHandler(IClienteQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<List<Cliente>> Handle(GetAllClienteQuery request, CancellationToken cancellationToken)
        {
            return (List<Cliente>)await _customerQueryRepository.GetAllAsync();
        }
    }
}
