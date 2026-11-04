using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.SalasDto
{
    public class ModificarSala
    {
        public int Capacidade { get; set; }
        public StatusSala Status { get; set; }
    }
}
