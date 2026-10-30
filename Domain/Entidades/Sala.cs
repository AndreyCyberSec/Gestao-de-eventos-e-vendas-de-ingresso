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
        public List<Cadeiras> CadeirasDisponiveis { get; private set;} = new List<Cadeiras>();

        public StatusSala Status { get; private set; } = StatusSala.Disponivel;

        protected Sala() { }

        private Sala(int numeroSala, int capacidade)
        {
            RegrasNumeroSala(numeroSala);
            RegrasCapacidade(capacidade);

            IdSala = Guid.NewGuid();
            NumeroSala = numeroSala;
            Capacidade = capacidade;
            Status = StatusSala.Disponivel;
        }

        public static Sala CreateSala(int numeroSala, int capacidade)
        {
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
            if(cadeira == null)
            {
                throw new ArgumentNullException(nameof(cadeira), "A cadeira não pode ser nula.");
            }

            bool cadeiraJaReservada = CadeirasDisponiveis.Any(c => c.NumeroCadeira == cadeira.NumeroCadeira);

            if(cadeiraJaReservada)
            {
                throw new InvalidOperationException($"A cadeira {cadeira.NumeroCadeira} já está reservada.");
            }
            if(CadeirasDisponiveis.Count >= Capacidade)
            {
                throw new InvalidOperationException("A sala atingiu sua capacidade máxima de cadeiras.");
            }

            CadeirasDisponiveis.Add(cadeira);
        }

        public void AdicionarEvento(Evento evento)
        {
            if (evento == null)
            {
                throw new ArgumentNullException(nameof(evento), "O evento não pode ser nulo.");
            }
            if(Eventos.Any(e => e.IdEvento == evento.IdEvento))
            {
                throw new InvalidOperationException($"O evento {evento.NomeEvento} já está associado a esta sala.");
            }
            Eventos.Add(evento);
        }

        public void AdicionarSessao(Sessao sessao)
        {
            if (sessao == null)
            {
                throw new ArgumentNullException(nameof(sessao), "A sessão não pode ser nula.");
            }
            if(Sessoes.Any(s => s.IdSessao == sessao.IdSessao))
            {
                throw new InvalidOperationException($"A sessão já está associada a esta sala.");
            }

            bool sessaoConflitante = Sessoes.Any(s => (sessao.DataHoraInicio < s.DataHoraFim && sessao.DataHoraFim > s.DataHoraInicio));
            if(sessaoConflitante)
            {
                throw new InvalidOperationException("A sessão conflita com outra sessão existente na sala.");
            }
            Sessoes.Add(sessao);
        }


        public void AlterarStatusSala()
        {
            Status = StatusSala.Indisponivel;
        }

    }
}
