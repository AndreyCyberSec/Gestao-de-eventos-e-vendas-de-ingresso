using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Sala
    {
        public Guid IdSala { get; private set; }
        public int NumeroSala { get; private set; }
        public int Capacidade { get; private set; } = 10;
        public List<Sessao> Sessoes { get; private set; } = new List<Sessao>();
        public List<Evento> Eventos { get; private set; } = new List<Evento>();
        public List<Cadeiras> CadeirasDisponiveis { get; private set;}

        public StatusSala Status { get; private set; } = StatusSala.Disponivel;

        protected Sala() { }

        private Sala(int numeroSala, int capacidade)
        {
            IdSala = Guid.NewGuid();
            NumeroSala = numeroSala;
            Capacidade = capacidade;
            Status = StatusSala.Disponivel;
        }

        public static Sala CreateSala(int numeroSala, int capacidade)
        {
            var sala = new Sala();
            sala.RegrasNumeroSala(numeroSala);
            sala.RegrasCapacidade(capacidade);
            return new Sala(numeroSala, capacidade);
        }

        public void RegrasCapacidade(int capacidade)
        {
            if (capacidade < 10 || capacidade > 100)
            {
                throw new ArgumentException("A capacidade da sala deve ser entre 10 e 100.");
            }
            Capacidade = capacidade;
        }

        public void RegrasNumeroSala(int numeroSala)
        {
            if (numeroSala < 1 || numeroSala > 10)
            {
                throw new ArgumentException("O número da sala deve ser entre 1 e 10.");
            }
            NumeroSala = numeroSala;
        }

        public void AdicionarCadeira(Cadeiras cadeira)
        {
            var cadeiraExistente = CadeirasDisponiveis.FirstOrDefault(c => c.NumeroCadeira == cadeira.NumeroCadeira);
            var cadeirasNaSala = CadeirasDisponiveis.Count;
            var cadeirasReservadas = CadeirasDisponiveis.Count(c => c.Status == StatusCadeira.Indisponivel);
            if (cadeiraExistente != null)
            {
                throw new ArgumentException($"A cadeira {cadeira.NumeroCadeira} já existe na sala.");
            }
            if (cadeirasNaSala >= Capacidade)
            {
                throw new ArgumentException("A sala já atingiu sua capacidade máxima de cadeiras.");
            }
            if(cadeirasReservadas == Capacidade)
            {
                throw new ArgumentException("Todas as cadeiras da sala estão reservadas.");
            }
            
            CadeirasDisponiveis.Add(cadeira);
        }

        public void AdicionarEvento(Evento evento)
        {
            Eventos.Add(evento);
        }

        public void AdicionarSessao(Sessao sessao)
        {
            Sessoes.Add(sessao);
        }


        public void AlterarStatusSala()
        {
            Status = StatusSala.Indisponivel;
        }

    }
}
