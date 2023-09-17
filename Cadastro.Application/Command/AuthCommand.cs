using Cadastro.Core.Entities;
using MediatR;

namespace Cadastro.Application.Command
{
    public class AuthCommand : IRequest<Login>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
