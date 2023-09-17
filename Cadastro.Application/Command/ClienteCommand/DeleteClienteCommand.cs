using MediatR;

namespace Cadastro.Application.Command.ClienteCommand
{
    public class DeleteClienteCommand : IRequest<string>
    {
        public Guid IdGuid { get; set; }

        public DeleteClienteCommand(Guid Id)
        {
            this.IdGuid = Id;
        }
    }
}
