using Cadastro.Core.Entities;
using MediatR;

namespace Cadastro.Application.Queries.LogradouroQuery
{
    public class GetLogradouroByIdQuery : IRequest<Logradouro>
    {
        public Guid Id { get; private set; }

        public GetLogradouroByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
