using Domain.Enum;
using Domain.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Cliente
    {
        public Guid IdCliente { get; private set; }
        public ObjectNome Nome { get; private set; }
        public int Idade { get; private set; }
        public ObjectEmail Email { get; private set; }
        public ObjectSenha Senha { get; private set; } 
        public TipoDeCliente TipoDeCliente { get; private set; }
        public StatusCliente StatusCliente { get; private set; }

        protected Cliente() { }

        private Cliente(ObjectNome nome, int idade, ObjectEmail email, ObjectSenha senha)
        {
            IdCliente = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
            Email = email;
            Senha = senha;
           TipoDeCliente = TipoDeCliente.Comum;
            StatusCliente = StatusCliente.Ativo;
        }

        public static Cliente CriarCliente(ObjectNome nome, int idade, ObjectEmail email, ObjectSenha senha)
        {
            if (idade < 18)
                throw new ArgumentException("O cliente deve ter pelo menos 18 anos.", nameof(idade));
            return new Cliente(nome, idade, email, senha);
        }

        public void AtualizarCliente(ObjectNome nome, int idade)
        {
            if (idade < 18)
                throw new ArgumentException("O cliente deve ter pelo menos 18 anos.", nameof(idade));
            Nome = nome;
            Idade = idade;
        }

        public void RedefinirSenha(ObjectSenha novaSenha)
        {
            Senha = novaSenha;
        }
        public void PromoverParaAdministrador()
        {
            TipoDeCliente = TipoDeCliente.Administrador;
        }
        public void RebaixarParaComum()
        {
            TipoDeCliente = TipoDeCliente.Comum;
        }
        public void DesativarCliente()
        {
            StatusCliente = StatusCliente.Inativo;
        }
        public void AtivarCliente()
        {
            StatusCliente = StatusCliente.Ativo;

        }
     }
}
