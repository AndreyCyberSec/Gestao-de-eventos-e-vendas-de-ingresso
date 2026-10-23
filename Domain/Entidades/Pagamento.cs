using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Pagamento
    {
        public Guid IdPagamento { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataPagamento { get; private set; } = DateTime.UtcNow;
        public MetodoPagamento TipoPagamento { get; private set; }

        public StatusPagamento Status { get; private set; }
        protected Pagamento() { }
        private Pagamento(decimal valor, MetodoPagamento tipoPagamento)
        {
            IdPagamento = Guid.NewGuid();
            Valor = valor;
            TipoPagamento = tipoPagamento;
            Status = StatusPagamento.Aprovado;
            DataPagamento = DateTime.UtcNow;

        }
        public static Pagamento CreatePagamento(decimal valor, MetodoPagamento tipoPagamento, StatusPagamento status)
        {
            return new Pagamento(valor, tipoPagamento) { Status = status };
        }

        public void ReprovarPagamento()
        {
            Status = StatusPagamento.Reprovado;
        }
    }
}
