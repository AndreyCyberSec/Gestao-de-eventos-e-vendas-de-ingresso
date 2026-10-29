using Domain.Entidades;
using Domain.Enum;
using Domain.ObjectValue.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios.Entidades
{
    public class TestesEventos
    {
        [Fact]
        public void TestarCriacaoEvento()
        {
          var evento1 = Evento.CreateEvento("Evento Teste", "Rua Teste", "Cidade Teste", SiglaEstado.BA, "Brasil", new DateTime(2024, 6, 1), new DateTime(2024, 6, 3), "Descrição do evento teste");
            Assert.NotNull(evento1);
            Assert.Equal("Evento Teste", evento1.NomeEvento.NomeEvento);
            Assert.Equal("Rua Teste", evento1.Endereco.Endereco);
            Assert.Equal("Cidade Teste", evento1.Endereco.Cidade);
            Assert.Equal(SiglaEstado.BA, evento1.Endereco.Estado);
            Assert.Equal("Brasil", evento1.Endereco.Pais);
            Assert.Equal(new DateTime(2024, 6, 1), evento1.DataInicioEvento);
            Assert.Equal(new DateTime(2024, 6, 3), evento1.DataFimEvento);
            Assert.Equal("Descrição do evento teste", evento1.DescricaoEvento.Descricao);
            Assert.Equal(StatusEvento.Disponível, evento1.StatusEvento);
        }
        [Fact]
        public void TestarAtualizacaoEvento()
        {
            var evento1 = Evento.CreateEvento("Evento Teste", "Rua Teste", "Cidade Teste", SiglaEstado.BA, "Brasil", new DateTime(2024, 6, 1), new DateTime(2024, 6, 3), "Descrição do evento teste");
            evento1.AtualizarEvento("Evento Atualizado", "Rua Atualizada", "Cidade Atualizada", SiglaEstado.SP, "Brasil", new DateTime(2024, 7, 1), new DateTime(2024, 7, 3), "Descrição do evento atualizada");
            Assert.Equal("Evento Atualizado", evento1.NomeEvento.NomeEvento);
            Assert.Equal("Rua Atualizada", evento1.Endereco.Endereco);
            Assert.Equal("Cidade Atualizada", evento1.Endereco.Cidade);
            Assert.Equal(SiglaEstado.SP, evento1.Endereco.Estado);
            Assert.Equal("Brasil", evento1.Endereco.Pais);
            Assert.Equal(new DateTime(2024, 7, 1), evento1.DataInicioEvento);
            Assert.Equal(new DateTime(2024, 7, 3), evento1.DataFimEvento);
            Assert.Equal("Descrição do evento atualizada", evento1.DescricaoEvento.Descricao);
        }

        [Fact]
        public void TestarAlterarStatusEvento()
        {
            var evento1 = Evento.CreateEvento("Evento Teste", "Rua Teste", "Cidade Teste", SiglaEstado.BA, "Brasil", new DateTime(2024, 6, 1), new DateTime(2024, 6, 3), "Descrição do evento teste");
            evento1.AlterarStatusEventoIndisponivel();
            Assert.Equal(StatusEvento.Indisponível, evento1.StatusEvento);
        }
        [Fact]
        public void TestarAlterarStatusEventoDisponivel()
        {
            var evento1 = Evento.CreateEvento("Evento Teste", "Rua Teste", "Cidade Teste", SiglaEstado.BA, "Brasil", new DateTime(2024, 6, 1), new DateTime(2024, 6, 3), "Descrição do evento teste");
            evento1.AlterarStatusEventoIndisponivel();
            evento1.AlterarStatusEventoDisponivel();
            Assert.Equal(StatusEvento.Disponível, evento1.StatusEvento);
        }

        [Fact]
        public void TestarCriacaoEventoComDataInvalida()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var evento1 = Evento.CreateEvento("Evento Teste", "Rua Teste", "Cidade Teste", SiglaEstado.BA, "Brasil", new DateTime(2024, 6, 3), new DateTime(2024, 6, 1), "Descrição do evento teste");
            });
        }
        [Fact]
        public void TestarAtualizacaoEventoComDataInvalida()
        {
            var evento1 = Evento.CreateEvento("Evento Teste", "Rua Teste", "Cidade Teste", SiglaEstado.BA, "Brasil", new DateTime(2024, 6, 1), new DateTime(2024, 6, 3), "Descrição do evento teste");
            Assert.Throws<ArgumentException>(() =>
            {
                evento1.AtualizarEvento("Evento Atualizado", "Rua Atualizada", "Cidade Atualizada", SiglaEstado.SP, "Brasil", new DateTime(2024, 7, 3), new DateTime(2024, 7, 1), "Descrição do evento atualizada");
            });
        }
    }
}
