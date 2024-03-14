using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoAutenticacao.Models;
using ProjetoAutenticacao.Repositories;
using ProjetoAutenticacao.Services;

namespace ProjetoAutenticacao.Controllers
{
    [Route("v1")]
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model){
            var result = UserRepository.Get(model.Username, model.Password);

            if(result.ErrorMessage != null) return result.ErrorMessage;

            var token = TokenService.GenerateToken(result.User);

            //Oculta a senha
            result.User.Password = "";

            return new {
                user = result.User,
                token = token
            };
        }
    }
}