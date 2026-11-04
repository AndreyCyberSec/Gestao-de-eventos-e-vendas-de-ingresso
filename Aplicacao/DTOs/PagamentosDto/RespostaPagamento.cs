using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.DTOs.PagamentosDto
{
    public class RespostaPagamento
    {
        public Guid IdPagamento { get; set; }
        public Guid IdIngresso { get; set; }
        public decimal Valor { get; set; }
        public string TipoPagamento { get; set; }
        public string Status { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
