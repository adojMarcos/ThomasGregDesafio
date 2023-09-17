using MediatR;

namespace Cadastro.Application.Command.LogradouroCommand
{
    public class DeleteLogradouroCommand : IRequest<String>
    {
        public Guid IdGuid { get; set; }

        public DeleteLogradouroCommand(Guid Id)
        {
            this.IdGuid = Id;
        }
    }
}
