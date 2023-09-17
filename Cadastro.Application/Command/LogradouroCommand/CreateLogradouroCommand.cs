using Cadastro.Application.Response;
using MediatR;

namespace Cadastro.Application.Command.LogradouroCommand
{
    public class CreateLogradouroCommand : IRequest<LogradouroResponse>
    {
        public Guid IdGuid { get; set; }
        public string LogradouroNome { get; set; } = string.Empty;
        public Guid IdCliente { get; set; }
    }
}
