using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Services
{
    public interface ISenhaHash
    {
        public string GerarHash(string senha);
        public bool VerificarHash(string senha, string hash);
    }
}
