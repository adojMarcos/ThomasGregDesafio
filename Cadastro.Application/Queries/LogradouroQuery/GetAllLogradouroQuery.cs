using Cadastro.Core.Entities;
using MediatR;

namespace Cadastro.Application.Queries.LogradouroQuery
{
    public class GetAllLogradouroQuery : IRequest<List<Logradouro>>
    {
    }
}
