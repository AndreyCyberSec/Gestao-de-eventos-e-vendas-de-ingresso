using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Sessao
    {
        public Guid IdSessao { get; private set; }
        public Guid IdEvento { get; private set; }
        public Guid IdSala { get; private set; }
        public DateTime DataHoraInicio { get; private set; }
        public DateTime DataHoraFim { get; private set; }
        protected Sessao() { }
        private Sessao(Guid idEvento, Guid idSala, DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            IdSessao = Guid.NewGuid();
            IdEvento = idEvento;
            IdSala = idSala;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
        }
        public static Sessao CreateSessao(Guid idEvento, Guid idSala, DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            return new Sessao(idEvento, idSala, dataHoraInicio, dataHoraFim);
        }
    }
}
