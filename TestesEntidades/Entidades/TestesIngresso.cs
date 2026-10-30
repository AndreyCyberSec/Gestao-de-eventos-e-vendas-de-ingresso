using Domain.Entidades;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios.Entidades
{
    public class TestesIngresso
    {
        [Fact]
        public void TestarCriacaoIngresso()
        {
            var ingresso = Ingresso.CreateIngresso(100.00m, 12345, TipoDeIngresso.Inteira);
            Assert.NotNull(ingresso);
            Assert.Equal(100.00m, ingresso.Preco.Valor);
            Assert.Equal(12345, ingresso.CodigoIngresso);
            Assert.Equal(TipoDeIngresso.Inteira, ingresso.TipoDeingresso);
            Assert.Equal(StatusDoIngresso.Disponivel, ingresso.Status);
        }
        [Fact]
        public void TestarAtualizacaoPrecoIngresso()
        {
            var ingresso = Ingresso.CreateIngresso(100.00m, 12345, TipoDeIngresso.Meia);
            ingresso.AtualizarPreco(150.00m);
            Assert.Equal(150.00m, ingresso.Preco.Valor);
        }
        [Fact]
        public void TestarAlterarStatusIngresso()
        {
            var ingresso = Ingresso.CreateIngresso(100.00m, 12345, TipoDeIngresso.Idoso);
            ingresso.IngressoIndisponivel();
            Assert.Equal(StatusDoIngresso.Indisponivel, ingresso.Status);
        }
        [Fact]
        public void TestarCriacaoIngressoComValorNegativo()
        {
            Assert.Throws<ArgumentException>(() => Ingresso.CreateIngresso(-50.00m, 12345, TipoDeIngresso.Inteira));
        }
    }
}
