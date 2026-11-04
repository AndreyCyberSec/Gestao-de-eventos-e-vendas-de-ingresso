using Domain.Enum;
using Domain.ObjectValue.Pagamento;
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
        public Guid Idingresso { get; private set; }
        public ObjectDinheiro  Valor { get; private set; }
        public DateTime DataPagamento { get; private set; } = DateTime.UtcNow;
        public MetodoPagamento TipoPagamento { get; private set; }

        public StatusPagamento Status { get; private set; }
        public Ingresso Ingresso { get; private set; }
        protected Pagamento() { }
        private Pagamento(Guid idIngresso, ObjectDinheiro valor, MetodoPagamento tipoPagamento)
        {
            IdPagamento = Guid.NewGuid();
            Idingresso = idIngresso;
            Valor = valor;
            TipoPagamento = tipoPagamento;
            Status = StatusPagamento.Pendente;
            DataPagamento = DateTime.UtcNow;

        }
        public static Pagamento CreatePagamento(Guid idIngresso, decimal valor, MetodoPagamento tipoPagamento)
        {
            if (idIngresso == Guid.Empty)
                throw new ArgumentException("Ingresso inválido.");
            var dinheiro = ObjectDinheiro.CreateValor(valor);

            return new Pagamento(idIngresso, dinheiro, tipoPagamento);
        }

        public void AprovarPagamento()
        {
            if(Status != StatusPagamento.Pendente)
            {
                throw new InvalidOperationException("Apenas pagamentos pendentes podem ser aprovados.");
            }
            Status = StatusPagamento.Aprovado;
            DataPagamento = DateTime.UtcNow;
        }

        public void ReprovarPagamento()
        {
            if (Status != StatusPagamento.Pendente)
            {
                throw new InvalidOperationException("Apenas pagamentos pendentes podem ser reprovados.");
            }
            Status = StatusPagamento.Reprovado;
            DataPagamento = DateTime.UtcNow;
        }
    }
}
