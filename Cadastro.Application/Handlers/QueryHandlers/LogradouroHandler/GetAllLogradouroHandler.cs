using Cadastro.Application.Queries.LogradouroQuery;
using Cadastro.Core.Entities;
using Cadastro.Core.Repositories.Query;
using MediatR;

namespace Cadastro.Application.Handlers.QueryHandlers.LogradouroHandler
{
    public class GetAllLogradouroHandler : IRequestHandler<GetAllLogradouroQuery, List<Logradouro>>
    {
        private readonly ILogradouroQueryRepository _queryRepository;

        public GetAllLogradouroHandler(ILogradouroQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<Logradouro>> Handle(GetAllLogradouroQuery request, CancellationToken cancellationToken)
        {
            return (List<Logradouro>)await _queryRepository.GetAllAsync();
        }
    }
}

