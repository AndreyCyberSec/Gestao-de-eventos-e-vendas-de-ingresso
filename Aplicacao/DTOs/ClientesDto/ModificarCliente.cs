using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.ClientesDto
{
    public class ModificarCliente
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public int Idade { get; set; }
    }
}
