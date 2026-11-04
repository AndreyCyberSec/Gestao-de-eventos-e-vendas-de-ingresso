using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.CadeirasDto
{
    public class RespostaCadeira
    {
        public string NumeroCadeira { get; set; }
        public string NomeSala { get; set; }
        public StatusCadeira Status { get; set; }
    }
}
