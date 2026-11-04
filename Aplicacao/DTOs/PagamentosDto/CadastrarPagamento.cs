using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.PagamentosDto
{
    public  class CadastrarPagamento
    {
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public MetodoPagamento  MetodoPagamento { get; set; }
    }
}
