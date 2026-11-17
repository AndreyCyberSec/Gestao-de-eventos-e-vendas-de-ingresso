using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.SessoesDto
{
    public class CadastrarSessao
    {
        public Guid IdEvento { get; set; }
        public Guid IdSala {  get; set; }
        public DateTime InicioSessao { get; set; }
        public DateTime FimSessao { get; set; }
    }
}
