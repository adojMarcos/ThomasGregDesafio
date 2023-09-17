using Cadastro.Application.Response;
using MediatR;

namespace Cadastro.Application.Command.ClienteCommand
{
    public class CreateClienteCommand : IRequest<ClienteResponse>
    {
        public Guid IdGuid { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
