using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Cadeiras
    {
        public Guid IdCadeira { get; private set; }
        public Guid IdSessao { get; private set; }
        public string NumeroCadeira { get; private set; }
        public StatusCadeira Status { get; private set; }
        protected Cadeiras() { }
        private Cadeiras(Guid idSessao, string numeroCadeira)
        {
            IdCadeira = Guid.NewGuid();
            IdSessao = idSessao;
            NumeroCadeira = numeroCadeira;
            Status = StatusCadeira.Disponivel;
        }
        public static Cadeiras CreateCadeira(Guid idSessao, string numeroCadeira)
        {
            return new Cadeiras(idSessao, numeroCadeira);
        }

        public void ReservarCadeira()
        {
            Status = StatusCadeira.Indisponivel;
        }

        public void LiberarCadeira()
        {
            Status = StatusCadeira.Disponivel;
        }
    }
}
