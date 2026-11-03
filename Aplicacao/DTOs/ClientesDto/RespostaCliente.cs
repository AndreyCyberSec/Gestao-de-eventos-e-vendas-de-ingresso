using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.ClientesDto
{
    public class RespostaCliente
    {
        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public int Idade { get; set; }

        public string Email { get; set; }

        public string TipoDeCliente { get; set; }

        public string StatusCliente { get; set; }
    }
}
