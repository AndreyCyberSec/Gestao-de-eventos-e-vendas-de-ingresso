using Domain.Entidades;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios.Entidades
{
    public class TestesPagamento
    {
        [Fact]
        public void TestarCriacaoPagamento()
        {
            var pagamento = Pagamento.CreatePagamento(200.00m, MetodoPagamento.Pix);
            Assert.NotNull(pagamento);
            Assert.Equal(200.00m, pagamento.Valor.Valor);
            Assert.Equal(StatusPagamento.Pendente, pagamento.Status);
        }
        [Fact]
        public void TestarAprovacaoPagamento()
        {
            var pagamento = Pagamento.CreatePagamento(200.00m, MetodoPagamento.CartaoCredito);
            pagamento.AprovarPagamento();
            Assert.Equal(StatusPagamento.Aprovado, pagamento.Status);
        }
        [Fact]
        public void TestarReprovacaoPagamento()
        {
            var pagamento = Pagamento.CreatePagamento(200.00m, MetodoPagamento.Boleto);
            pagamento.ReprovarPagamento();
            Assert.Equal(StatusPagamento.Reprovado, pagamento.Status);
        }
        [Fact]
        public void TestarPagamentoNegativo()
        {
            Assert.Throws<ArgumentException>(() => Pagamento.CreatePagamento(-100.00m, MetodoPagamento.Pix));
        }
        [Fact]
        public void TestarPagamentoAprovadoNaoPodeSerReprovado()
        {
            var pagamento = Pagamento.CreatePagamento(200.00m, MetodoPagamento.CartaoCredito);
            pagamento.AprovarPagamento();
            Assert.Throws<InvalidOperationException>(() => pagamento.ReprovarPagamento());
        }
        [Fact]
        public void TestarPagamentoReprovadoNaoPodeSerAprovado()
        {
            var pagamento = Pagamento.CreatePagamento(200.00m, MetodoPagamento.Boleto);
            pagamento.ReprovarPagamento();
            Assert.Throws<InvalidOperationException>(() => pagamento.AprovarPagamento());
        }

    }
}
