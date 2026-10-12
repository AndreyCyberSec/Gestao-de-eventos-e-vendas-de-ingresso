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

    }
}
