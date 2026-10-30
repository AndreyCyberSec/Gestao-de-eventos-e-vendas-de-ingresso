using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios.Entidades
{
    public class TestesSessao
    {
        [Fact]
        public void TestarCriacaoSessao()
        {
            var inicio = DateTime.UtcNow;
            var fim = inicio.AddHours(2);

            var sessao = Sessao.CreateSessao(Guid.NewGuid(), Guid.NewGuid(), inicio, fim);
            Assert.NotNull(sessao);
            Assert.Equal(inicio, sessao.DataHoraInicio);
            Assert.Equal(fim, sessao.DataHoraFim);
        }
        [Fact]
        public void TestarSessaoComHorarioFimAntesDoInicio()
        {
            Assert.Throws<ArgumentException>(() => Sessao.CreateSessao(Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddHours(-1)));
        }
    }
}
