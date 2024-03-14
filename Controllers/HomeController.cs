using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoAutenticacao.Models;

namespace ProjetoAutenticacao.Controllers;

[ApiController]
public class HomeController : ControllerBase
{

    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo";

    [HttpGet]
    [Route("authenticated")]
    [Authorize]
    public string Authenticated() => $"Autenticado - {User.Identity.Name}";

    [HttpGet]
    [Route("animal")]
    [Authorize(Roles = "Animal,Manager")]
    public string Employee() => "Animal";

    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = "Manager")]
    public string Manager() => "Manager";

}
