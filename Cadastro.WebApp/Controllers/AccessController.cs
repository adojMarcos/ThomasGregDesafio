using Cadastro.Application.Command;
using Cadastro.WebApp.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cadastro.WebApp.Controllers
{
    public class AccessController : Controller
    {
        private readonly IMediator _mediator;
        public AccessController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login modelLogin)
        {

            try
            {
                if (ModelState.IsValid)
                {


                    AuthCommand command = new AuthCommand
                    {
                        Password = modelLogin.PassWord,
                        Email = modelLogin.Email,
                    };

                    var user = await _mediator.Send(command);

                    if (modelLogin.Email == "admin@admin.com" && modelLogin.PassWord == "admin")
                    {
                        List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim("OtherProperties","Example Role")

                };

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        AuthenticationProperties properties = new AuthenticationProperties()
                        {

                            AllowRefresh = true,
                            IsPersistent = modelLogin.KeepLoggedIn
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), properties);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            ViewData["ValidateMessage"] = "Usuário não encontrado";
            return View();
        }
    }
}
