using Domain.Entidades;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios.Entidades
{
    public class TestesCliente
    {
        [Fact]
        public void TestarCriacaoCliente()
        {
            var cliente1 = Cliente.CriarCliente("João", "Santos", 30, "joao@gmail.com", "J@ao5921");
            Assert.NotNull(cliente1);
            Assert.Equal("João", cliente1.Nome.PrimeiroNome);
            Assert.Equal("Santos", cliente1.Nome.UltimoNome);
            Assert.Equal(30, cliente1.Idade);
            Assert.Equal("joao@gmail.com", cliente1.Email.corpoEmail);
            Assert.Equal("J@ao5921", cliente1.Senha.Senha);
            Assert.Equal(TipoDeCliente.Comum, cliente1.TipoDeCliente);
            Assert.Equal(StatusCliente.Ativo, cliente1.StatusCliente);
        }
        [Fact]
        public void TestarAtualizacaoCliente()
        {
            var cliente1 = Cliente.CriarCliente("João", "Santos", 30, "joao@gmail.com", "J@ao5921");
            cliente1.AtualizarCliente("João", "Silva", 35);
            Assert.Equal("João", cliente1.Nome.PrimeiroNome);
            Assert.Equal("Silva", cliente1.Nome.UltimoNome);
            Assert.Equal(35, cliente1.Idade);
        }
        [Fact]
        public void TestarRedefinicaoSenha()
        {
            var cliente1 = Cliente.CriarCliente("João", "Santos", 30, "joao@gmail.com", "J@ao5921");
            cliente1.RedefinirSenha("NovaSenha@123");
            Assert.Equal("NovaSenha@123", cliente1.Senha.Senha);
        }
        [Fact]
        public void TestarPromocaoParaAdministrador()
        {
            var cliente1 = Cliente.CriarCliente("João", "Santos", 30, "joao@gmail.com", "J@ao5921");
            cliente1.PromoverParaAdministrador();
            Assert.Equal(TipoDeCliente.Administrador, cliente1.TipoDeCliente);
        }
        [Fact]
        public void TestarRebaixamentoParaComum()
        {
            var cliente1 = Cliente.CriarCliente("João", "Santos", 30, "joao@gmail.com", "J@ao5921");
            cliente1.PromoverParaAdministrador();
            cliente1.RebaixarParaComum();
            Assert.Equal(TipoDeCliente.Comum, cliente1.TipoDeCliente);
        }
        [Fact]
        public void TestarDesativacaoCliente()
        {
            var cliente1 = Cliente.CriarCliente("João", "Santos", 30, "joao@gmail.com", "J@ao5921");
            cliente1.DesativarCliente();
            Assert.Equal(StatusCliente.Inativo, cliente1.StatusCliente);
        }
        [Fact]
        public void TestarAtivacaoCliente()
        {
            var cliente1 = Cliente.CriarCliente("João", "Santos", 30, "joao@gmail.com", "J@ao5921");
            cliente1.DesativarCliente();
            cliente1.AtivarCliente();
            Assert.Equal(StatusCliente.Ativo, cliente1.StatusCliente);
        }
        [Fact]
        public void TestarCriacaoClienteComIdadeInvalida()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var cliente1 = Cliente.CriarCliente("João", "Santos", 17, "joao@gmail.com", "J@ao5921");
            });
        }
        [Fact]
        public void TestarSenhaInvalida()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var cliente1 = Cliente.CriarCliente("João", "Santos", 30, "joao@gmail.com", "1234");
            });
        }
    }
}
