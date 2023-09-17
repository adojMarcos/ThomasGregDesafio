using Cadastro.Application.Queries.ClienteQuery;
using Cadastro.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Cliente>> Get()
        {
            return await _mediator.Send(new GetAllClienteQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Cliente> Get(Guid id)
        {
            return await _mediator.Send(new GetClienteByIdQuery(id));
        }
    }
}
