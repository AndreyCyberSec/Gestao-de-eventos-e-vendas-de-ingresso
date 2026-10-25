using Domain.Enum;
using Domain.ObjectValue.Evento;
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
        public Guid IdSessao { get; private set; }
        public Guid IdSala { get; private set; }
        public Guid IdIngresso { get; private set; }
        public ObejctNomeEvento NomeEvento { get; private set; }
        public ObjectLocalEvento Endereco { get; private set; }
        public DateTime DataInicioEvento { get; private set; }
        public DateTime DataFimEvento { get; private set; }
        public ObjectDescricaoEvento DescricaoEvento { get; private set; }

        public StatusEvento StatusEvento { get; private set; }

        protected Evento() { }

        private Evento(Guid idSessao,Guid Idsala, Guid Idingresso,ObejctNomeEvento nomeEvento, ObjectLocalEvento endereco, DateTime dataInicioEvento, DateTime dataFimEvento, ObjectDescricaoEvento descricaoEvento)
        {
            IdEvento = Guid.NewGuid();
            IdSessao = idSessao;
            IdSala = Idsala;
            IdIngresso = Idingresso;
            NomeEvento = nomeEvento;
            Endereco = endereco;
            DataInicioEvento = dataInicioEvento;
            DataFimEvento = dataFimEvento;
            DescricaoEvento = descricaoEvento;
            StatusEvento = StatusEvento.Disponível;
        }

        public static Evento CreateEvento(Guid IdSessao, Guid Idsala,Guid Idingresso,ObejctNomeEvento nomeEvento, string endereco,string cidade,SiglaEstado estado, string pais, DateTime dataInicioEvento, DateTime dataFimEvento, ObjectDescricaoEvento descricaoEvento)
        {
            var localEvento = ObjectLocalEvento.CreateLocalEvento(endereco, cidade, estado, pais);
            return new Evento(IdSessao, Idsala, Idingresso, nomeEvento, localEvento, dataInicioEvento, dataFimEvento, descricaoEvento);
        }

        public void AtualizarEvento(ObejctNomeEvento nomeEvento, string endereco, string cidade, SiglaEstado estado, string pais, DateTime dataInicioEvento, DateTime dataFimEvento, ObjectDescricaoEvento descricaoEvento)
            {
                var localEvento = ObjectLocalEvento.CreateLocalEvento(endereco, cidade, estado, pais);
                NomeEvento = nomeEvento;
                Endereco = localEvento;
                DataInicioEvento = dataInicioEvento;
                DataFimEvento = dataFimEvento;
                DescricaoEvento = descricaoEvento;
        }

        public void AlterarStatusEventoIndisponivel()
        {
            StatusEvento = StatusEvento.Indisponível;
        }

        public void AlterarStatusEventoDisponivel()
        {
            StatusEvento = StatusEvento.Disponível;
        }

        

        


    }
}
