using Cadastro.Core.Entities;
using MediatR;

namespace Cadastro.Application.Queries.ClienteQuery
{
    public class GetAllClienteQuery : IRequest<List<Cliente>>
    {

    }
}
