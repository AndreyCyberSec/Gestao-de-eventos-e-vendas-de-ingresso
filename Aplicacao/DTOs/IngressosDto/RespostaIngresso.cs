using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.IngressosDto
{
    public class RespostaIngresso
    {
        public decimal Valor { get; set; }
        public int CodigoIngresso { get; set; }
        public TipoDeIngresso TipoDeIngresso { get; set; }
        public StatusDoIngresso StatusDoIngresso { get; set; }
    }
}
