using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAutenticacao.Models;

namespace ProjetoAutenticacao.Result
{
    public class AuthenticatedResult
    {
        public User? User { get; set; }
        public string? ErrorMessage { get; set; }
    }
}