using ProjetoTeste.DTO.Security;
using System.Collections.Generic;
using System.Linq;


namespace ProjetoTeste.Repositories.Security
{
    public class AuthRepository
    {
        private readonly List<LoginDTO> _usuarios;

        public AuthRepository()
        {
            // teste
            _usuarios = new List<LoginDTO>
            {
                new LoginDTO("admin", "admin"),
                new LoginDTO("teste", "teste")
            };
        }

        /// <summary>
        /// Consulta um usuário pelo login e senha
        /// </summary>
        public LoginDTO? ConsultaPeloLogin(string usuario, string senha)
        {
            return _usuarios.FirstOrDefault(u => u.Usuario == usuario && u.Senha == senha);
        }
    }
}
