using Infraestrutura.Interface.Senha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.ServiceHashSenha
{
    public class BcryptServiceSenhaHash : IServiceSenhaHash
    {
        public string GerarHash(string senha)
        {
           return BCrypt.Net.BCrypt.HashPassword(senha, workFactor: 12);
        }

        public bool VerificarHash(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}
