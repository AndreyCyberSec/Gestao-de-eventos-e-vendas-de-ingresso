using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Cadeira
    {
        public Guid IdCadeira { get; private set; }
        public Guid IdSala { get; private set; }
        public string NumeroCadeira { get; private set; }
        public StatusCadeira Status { get; private set; }
        public Sala Sala { get; private set; }
        protected Cadeira() { }
        private Cadeira(string numeroCadeira,Guid idSala)
        {
            IdCadeira = Guid.NewGuid();
            IdSala = idSala;
            NumeroCadeira = numeroCadeira;
            Status = StatusCadeira.Disponivel;
        }
        public static Cadeira CreateCadeira(string numeroCadeira, Guid idSala)
        {
            if(string.IsNullOrEmpty(numeroCadeira))
            {
                throw new ArgumentException("Número da cadeira não pode ser nulo ou vazio.");
            }
            
            return new Cadeira(numeroCadeira, idSala);
           
        }

        public void ReservarCadeira()
        {
            if(Status == StatusCadeira.Indisponivel)
            {
                throw new InvalidOperationException("Cadeira já está reservada.");
            }
            Status = StatusCadeira.Indisponivel;
        }

        public void LiberarCadeira()
        {
            Status = StatusCadeira.Disponivel;
        }
    }
}
