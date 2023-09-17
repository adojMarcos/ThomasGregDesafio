using Cadastro.Application.Queries.LogradouroQuery;
using Cadastro.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogradouroController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LogradouroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Logradouro>> Get()
        {
            return await _mediator.Send(new GetAllLogradouroQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Logradouro> Get(Guid id)
        {
            return await _mediator.Send(new GetLogradouroByIdQuery(id));
        }

    }
}
