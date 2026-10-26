using Domain.Entidades;
using Domain.Enum;

namespace TestesUnitarios.Entidades
{
    public class TestesCadeira
    {
        [Fact]

        public void TestarCriacaoDeCadeira()
        {
            var cadeira = Cadeiras.CreateCadeira(Guid.NewGuid(), "A1");
            Assert.NotNull(cadeira);
            Assert.Equal("A1", cadeira.NumeroCadeira);
            Assert.Equal(StatusCadeira.Disponivel, cadeira.Status);
        }
        [Fact]

        public void TestarReservaDeCadeira()
        {
            var cadeira = Cadeiras.CreateCadeira(Guid.NewGuid(), "A1");
            cadeira.ReservarCadeira();
            Assert.Equal(StatusCadeira.Indisponivel, cadeira.Status);
        }
        [Fact]
        public void TestarLiberacaoDeCadeira()
        {
            var cadeira = Cadeiras.CreateCadeira(Guid.NewGuid(), "A1");
            cadeira.ReservarCadeira();
            if (cadeira.Status == StatusCadeira.Indisponivel) Console.WriteLine("Cadeira está reservada");
            cadeira.LiberarCadeira();
            if (cadeira.Status == StatusCadeira.Disponivel) Console.WriteLine("Cadeira está disponível");
            Assert.Equal(StatusCadeira.Disponivel, cadeira.Status);
        }
        [Fact]
        public void TestarReservaDeCadeiraJaReservada()
        {
            var cadeira = Cadeiras.CreateCadeira(Guid.NewGuid(), "A1");
            cadeira.ReservarCadeira();
            Assert.Throws<InvalidOperationException>(() =>
            { 
                cadeira.ReservarCadeira(); // Tenta reservar novamente
            });
        }
    }
}