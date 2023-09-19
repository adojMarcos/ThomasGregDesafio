using Cadastro.Application.Command.ClienteCommand;
using Cadastro.Application.Queries.ClienteQuery;
using Cadastro.Application.Queries.LogradouroQuery;
using Cadastro.WebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.WebApp.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IMediator _mediator;
        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {

            var clientes = await _mediator.Send(new GetAllClienteQuery());

            List<Models.Cliente> result = new();

            clientes.ForEach(cliente =>
            {
                result.Add(new Models.Cliente
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    IdGuid = cliente.IdGuid,
                });
            });

            return View(result);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var cliente = await _mediator.Send(new GetClienteByIdQuery(id));

            Models.Cliente result = new Models.Cliente
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                IdGuid = cliente.IdGuid,
                Logradouros = (await GetLogradouros()).Where(x => x.IdClient == cliente.IdGuid).ToList()
            };



            return View(result);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Models.Cliente request)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var guid = new Guid(Guid.NewGuid().ToString());

                    CreateClienteCommand command = new CreateClienteCommand
                    {
                        IdGuid = new Guid(Guid.NewGuid().ToString()),
                        Nome = request.Nome,
                        Email = request.Email,
                    };

                    await _mediator.Send(command);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return View(request);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var cliente = await _mediator.Send(new GetClienteByIdQuery(id));

            Models.Cliente result = new Models.Cliente
            {

                Nome = cliente.Nome,
                Email = cliente.Email,
                IdGuid = cliente.IdGuid,
            };

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Models.Cliente request)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var guid = new Guid(Guid.NewGuid().ToString());

                    UpdateClienteCommand command = new()
                    {
                        IdGuid = request.IdGuid,
                        Nome = request.Nome,
                        Email = request.Email,
                    };

                    await _mediator.Send(command);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return View(request);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var cliente = await _mediator.Send(new GetClienteByIdQuery(id));

            Models.Cliente result = new Models.Cliente
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                IdGuid = cliente.IdGuid,
            };

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteClienteCommand(id));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private async Task<List<Logradouro>> GetLogradouros()
        {
            try
            {
                var logradouros = await _mediator.Send(new GetAllLogradouroQuery());

                List<Models.Logradouro> result = new();

                logradouros.ForEach(logradouro =>
                {
                    result.Add(new Models.Logradouro
                    {
                        IdGuid = logradouro.IdGuid,
                        LogradouroNome = logradouro.LogradouroNome,
                        IdClient = logradouro.IdCliente
                    });
                });

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
