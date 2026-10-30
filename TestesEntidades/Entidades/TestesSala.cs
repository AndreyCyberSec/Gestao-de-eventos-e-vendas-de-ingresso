using Domain.Entidades;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios.Entidades
{
    public class TestesSala
    {
        [Fact]
        public void TestarCriacaoSala()
        {
            var sala = Sala.CreateSala(1, 100);
            Assert.NotNull(sala);
            Assert.Equal(1, sala.NumeroSala);
            Assert.Equal(100, sala.Capacidade);
        }
        [Fact]
        public void TestarCriacaoSalaComCapacidadeNegativa()
        {
            Assert.Throws<ArgumentException>(() => Sala.CreateSala(2, -50));
        }
        [Fact]
        public void TestarCriacaoSalaComNumeroInvalido()
        {
            Assert.Throws<ArgumentException>(() => Sala.CreateSala(11, 50));
        }
        [Fact]
        public void TestarAdicionarCadeiraNula()
        {
            var sala =  Sala.CreateSala(3, 50);
            Assert.Throws<ArgumentNullException>(() => sala.AdicionarCadeira(null));
        }
        [Fact]
        public void TestarAdicionarCadeiraValida()
        {
            var sala =  Sala.CreateSala(4, 50);
            var cadeira =  Cadeiras.CreateCadeira(Guid.NewGuid(), "A1");
            sala.AdicionarCadeira(cadeira);
            Assert.Contains(cadeira, sala.CadeirasDisponiveis);
        }
        [Fact]
        public void TestarAdicionarCadeiraDuplicada()
        {
            var sala =  Sala.CreateSala(5, 50);
            var cadeira =  Cadeiras.CreateCadeira(Guid.NewGuid(), "A1");
            sala.AdicionarCadeira(cadeira);
            Assert.Throws<InvalidOperationException>(() => sala.AdicionarCadeira(cadeira));
        }
        [Fact]
        public void TestarAdicionarCadeiraComMesmoNumero()
        {
            var sala =  Sala.CreateSala(6, 50);
            var cadeira1 =  Cadeiras.CreateCadeira(Guid.NewGuid(), "A1");
            var cadeira2 =  Cadeiras.CreateCadeira(Guid.NewGuid(), "A1");
            sala.AdicionarCadeira(cadeira1);
            Assert.Throws<InvalidOperationException>(() => sala.AdicionarCadeira(cadeira2));
        }
        [Fact]
        public void TestarAdicionarEventoValido()
        {
            var sala =  Sala.CreateSala(7, 50);
            var evento = Evento.CreateEvento("Evento Teste", "Rua Teste", "Cidade Teste", SiglaEstado.BA, "Brasil", new DateTime(2024, 6, 1), new DateTime(2024, 6, 3), "Descrição do evento teste");
            sala.AdicionarEvento(evento);
            Assert.Contains(evento, sala.Eventos);
        }
        [Fact]
        public void TestarAdicionarEventoNulo()
        {
            var sala =  Sala.CreateSala(8, 50);
            Assert.Throws<ArgumentNullException>(() => sala.AdicionarEvento(null));
        }
        [Fact]
        public void TestarAdicionarEventoDuplicado()
        {
            var sala =  Sala.CreateSala(9, 50);
            var evento = Evento.CreateEvento("Evento Teste", "Rua Teste", "Cidade Teste", SiglaEstado.BA, "Brasil", new DateTime(2024, 6, 1), new DateTime(2024, 6, 3), "Descrição do evento teste");
            sala.AdicionarEvento(evento);
            Assert.Throws<InvalidOperationException>(() => sala.AdicionarEvento(evento));
        }
        [Fact]
        public void TestarAdicionarSessaoValida()
        {
            var sala =  Sala.CreateSala(10, 50);
            var sessao = Sessao.CreateSessao(Guid.NewGuid(), Guid.NewGuid(), new DateTime(2024, 6, 1, 18, 0, 0), new DateTime(2024, 6, 1, 20, 0, 0));
            sala.AdicionarSessao(sessao);
            Assert.Contains(sessao, sala.Sessoes);
        }
        [Fact]
        public void TestarAdicionarSessaoNula()
        {
            var sala =  Sala.CreateSala(1, 50);
            Assert.Throws<ArgumentNullException>(() => sala.AdicionarSessao(null));
        }
    }
}
