using Cadastro.Core.Entities;
using MediatR;

namespace Cadastro.Application.Queries.ClienteQuery
{
    public class GetClienteByIdQuery : IRequest<Cliente>
    {
        public Guid Id { get; private set; }

        public GetClienteByIdQuery(Guid Id)
        {
            this.Id = Id;
        }

    }
}
