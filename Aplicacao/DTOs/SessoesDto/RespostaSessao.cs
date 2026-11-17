using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.SessoesDto
{
    public class RespostaSessao
    {
        public DateTime InicioSessao { get; set; }
        public DateTime FimSessao { get; set; }

        public int Capacidade { get; set; }
        public int QuantidadeReservada { get; set; }
        public int LugaresDisponiveis { get; set; }
        public bool EstaLotada { get; set; }

    }
}
