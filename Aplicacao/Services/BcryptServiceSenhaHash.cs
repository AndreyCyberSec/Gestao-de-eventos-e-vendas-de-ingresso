using Aplicacao.Interfaces.Services;
using Infraestrutura.Interface.Senha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Services
{
    public class BcryptServiceSenhaHash : ISenhaHash
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
