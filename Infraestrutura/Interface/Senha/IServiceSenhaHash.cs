using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Interface.Senha
{
    public interface IServiceSenhaHash
    {
        public string GerarHash(string senha);
        public bool VerificarHash(string senha, string hash);
    }
}
