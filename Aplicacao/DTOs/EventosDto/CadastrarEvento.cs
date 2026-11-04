using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.EventosDto
{
     
    public class CadastrarEvento
    {
        public string NomeEvento { get; set; }
        public string EnderecoEvento { get; set; }
        public string CidadeEvento { get; set; }
        public SiglaEstado EstadoEvento { get; set; }
        public string PaisEvento { get; set; }
        public DateTime InicioEvento { get; set; }
        public DateTime FimEvento { get; set; }
        public string DescricaoEvento { get; set; }
    }
}
