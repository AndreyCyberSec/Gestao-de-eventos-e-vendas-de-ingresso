using Aplicacao.DTOs.CadeirasDto;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.SalasDto
{
    public class RespostaSala
    {
        public int NumeroSala { get; set; }
        public int Capacidade { get; set; }
        public StatusSala Status { get; set; }
        public List<RespostaCadeira> Cadeiras { get; set; }
    }
}
