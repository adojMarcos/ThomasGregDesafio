using Cadastro.Application.Command.LogradouroCommand;
using Cadastro.Application.Queries.ClienteQuery;
using Cadastro.Application.Queries.LogradouroQuery;
using Cadastro.WebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.WebApp.Controllers
{
    [Authorize]
    public class LogradouroController : Controller
    {
        private readonly IMediator _mediator;
        public LogradouroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {

            var logradouros = await _mediator.Send(new GetAllLogradouroQuery());
            var clientes = await GetClientes();

            List<Models.Logradouro> result = new();

            logradouros.ForEach(logradouro =>
            {
                result.Add(new Models.Logradouro
                {
                    IdClient = logradouro.IdCliente,
                    ClienteName = clientes.Find(x => x.IdGuid == logradouro.IdCliente).Nome,
                    LogradouroNome = logradouro.LogradouroNome,
                    IdGuid = logradouro.IdGuid,
                });
            });

            return View(result);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var logradouro = await _mediator.Send(new GetLogradouroByIdQuery(id));

            Models.Logradouro result = new Models.Logradouro
            {
                IdClient = logradouro.IdCliente,
                LogradouroNome = logradouro.LogradouroNome,
                IdGuid = logradouro.IdGuid,
            };

            return View(result);
        }

        public async Task<ActionResult> Create()
        {
            var logradouroView = new Models.Logradouro();
            var clientes = await GetClientes();

            logradouroView.Clientes = clientes;
            return View(logradouroView);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Models.Logradouro request)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var guid = new Guid(Guid.NewGuid().ToString());

                    CreateLogradouroCommand command = new CreateLogradouroCommand
                    {
                        IdGuid = new Guid(Guid.NewGuid().ToString()),
                        IdCliente = request.IdClient,
                        LogradouroNome = request.LogradouroNome,
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
            var clientes = await GetClientes();

            var logradouro = await _mediator.Send(new GetLogradouroByIdQuery(id));

            Models.Logradouro result = new Models.Logradouro
            {

                IdClient = logradouro.IdCliente,
                LogradouroNome = logradouro.LogradouroNome,
                ClienteName = clientes.Find(x => x.IdGuid == logradouro.IdCliente).Nome,
                IdGuid = logradouro.IdGuid,
                Clientes = clientes
            };

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Models.Logradouro request)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var guid = new Guid(Guid.NewGuid().ToString());

                    UpdateLogradouroCommand command = new()
                    {
                        IdGuid = request.IdGuid,
                        IdCliente = request.IdClient,
                        LogradouroNome = request.LogradouroNome,
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
            var logradouro = await _mediator.Send(new GetLogradouroByIdQuery(id));

            Models.Logradouro result = new Models.Logradouro
            {
                IdClient = logradouro.IdCliente,
                LogradouroNome = logradouro.LogradouroNome,
                IdGuid = logradouro.IdGuid,
            };

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteLogradouroCommand(id));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private async Task<List<Cliente>> GetClientes()
        {
            try
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

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
