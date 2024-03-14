using ProjetoAutenticacao.Models;
using ProjetoAutenticacao.Result;

namespace ProjetoAutenticacao.Repositories
{
    public static class UserRepository
    {
        public static AuthenticatedResult Get(string username, string password){
            var users = new List<User>{
                new User { Id = 1, Username = "Pedro", Password = "123", Role = "Manager"},
                new User { Id = 2, Username = "Bubbles", Password = "456", Role = "Animal"}
            };

            var user = users.FirstOrDefault(x => x.Username == username);

            if(user == null) return new AuthenticatedResult { ErrorMessage = "Usuário Não Encontrado."};

            if(user.Password != password) return new AuthenticatedResult { ErrorMessage = "Senha inválida."};

            return new AuthenticatedResult { User = user};
        }
    }
}