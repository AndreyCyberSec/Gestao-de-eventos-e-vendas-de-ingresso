using Domain.Enum;
using Domain.ObjectValue.Evento;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Evento
    {
        public Guid IdEvento { get; private set; }
        public Guid IdSala { get; private set; }
        public ObejctNomeEvento NomeEvento { get; private set; }
        public ObjectLocalEvento Endereco { get; private set; }
        public DateTime DataInicioEvento { get; private set; }
        public DateTime DataFimEvento { get; private set; }
        public ObjectDescricaoEvento DescricaoEvento { get; private set; }
        public Sala Sala { get; private set; }
        public StatusEvento StatusEvento { get; private set; }

        public List<Sessao> Sessoes { get; private set; } = new();
        public List<Evento> Eventos { get; private set; } = new();

        protected Evento() { }

        private Evento(Guid idSala, ObejctNomeEvento nomeEvento, ObjectLocalEvento endereco, DateTime dataInicioEvento, DateTime dataFimEvento, ObjectDescricaoEvento descricaoEvento)
        {
            IdEvento = Guid.NewGuid();
            IdSala = idSala;
            NomeEvento = nomeEvento;
            Endereco = endereco;
            DataInicioEvento = dataInicioEvento;
            DataFimEvento = dataFimEvento;
            DescricaoEvento = descricaoEvento;
            StatusEvento = StatusEvento.Disponível;
        }

        public static Evento CreateEvento(Guid idSala, string nomeEvento, string endereco,string cidade,SiglaEstado estado, string pais, DateTime dataInicioEvento, DateTime dataFimEvento, string descricaoEvento)
        {
            if(dataInicioEvento > dataFimEvento)
            {
                throw new ArgumentException("A data de início do evento não pode ser posterior à data de término.");
            }
            var nomeEventoValido = ObejctNomeEvento.CreateNomeEvento(nomeEvento);
            var localEvento = ObjectLocalEvento.CreateLocalEvento(endereco, cidade, estado, pais);
            var descricaoEventoValida = ObjectDescricaoEvento.CreateDescricaoEvento(descricaoEvento);
            return new Evento(idSala, nomeEventoValido, localEvento, dataInicioEvento, dataFimEvento, descricaoEventoValida);
        }

        public void AtualizarEvento(string nomeEvento, string endereco, string cidade, SiglaEstado estado, string pais, DateTime dataInicioEvento, DateTime dataFimEvento, string descricaoEvento)
            {
                         if (dataInicioEvento > dataFimEvento)
                            {
                                throw new ArgumentException("A data de início do evento não pode ser posterior à data de término.");
                            }
            var nomeEventoValido = ObejctNomeEvento.CreateNomeEvento(nomeEvento);
            var localEvento = ObjectLocalEvento.CreateLocalEvento(endereco, cidade, estado, pais);
            var descricaoDoEvento = ObjectDescricaoEvento.CreateDescricaoEvento(descricaoEvento);
            NomeEvento = nomeEventoValido;
                Endereco = localEvento;
                DataInicioEvento = dataInicioEvento;
                DataFimEvento = dataFimEvento;
                DescricaoEvento = descricaoDoEvento;
        }

        public void AlterarStatusEventoIndisponivel()
        {
            StatusEvento = StatusEvento.Indisponível;
        }

        public void AlterarStatusEventoDisponivel()
        {
            StatusEvento = StatusEvento.Disponível;
        }

        public void AdicionarSessao(Sessao sessao)
        {
            if (sessao == null)
            {
                throw new ArgumentNullException(nameof(sessao), "A sessão não pode ser nula.");
            }
            if (Sessoes.Any(s => s.IdSessao == sessao.IdSessao))
            {
                throw new InvalidOperationException($"A sessão já está associada a esta sala.");
            }

            bool sessaoConflitante = Sessoes.Any(s => (sessao.DataHoraInicio < s.DataHoraFim && sessao.DataHoraFim > s.DataHoraInicio));
            if (sessaoConflitante)
            {
                throw new InvalidOperationException("A sessão conflita com outra sessão existente na sala.");
            }
            if (!Eventos.Any(e => e.IdEvento == sessao.IdEvento))
            {
                throw new InvalidOperationException(
                    "Este evento não está associado a esta sala.");
            }
            Sessoes.Add(sessao);
        }






    }
}
