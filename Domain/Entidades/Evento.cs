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
        public ObejctNomeEvento NomeEvento { get; private set; }
        public ObjectLocalEvento Endereco { get; private set; }
        public DateTime DataInicioEvento { get; private set; }
        public DateTime DataFimEvento { get; private set; }
        public ObjectDescricaoEvento DescricaoEvento { get; private set; }

        public StatusEvento StatusEvento { get; private set; }

        protected Evento() { }

        private Evento(ObejctNomeEvento nomeEvento, ObjectLocalEvento endereco, DateTime dataInicioEvento, DateTime dataFimEvento, ObjectDescricaoEvento descricaoEvento)
        {
            IdEvento = Guid.NewGuid();
            NomeEvento = nomeEvento;
            Endereco = endereco;
            DataInicioEvento = dataInicioEvento;
            DataFimEvento = dataFimEvento;
            DescricaoEvento = descricaoEvento;
            StatusEvento = StatusEvento.Disponível;
        }

        public static Evento CreateEvento(string nomeEvento, string endereco,string cidade,SiglaEstado estado, string pais, DateTime dataInicioEvento, DateTime dataFimEvento, string descricaoEvento)
        {
            if(dataInicioEvento > dataFimEvento)
            {
                throw new ArgumentException("A data de início do evento não pode ser posterior à data de término.");
            }
            var nomeEventoValido = ObejctNomeEvento.CreateNomeEvento(nomeEvento);
            var localEvento = ObjectLocalEvento.CreateLocalEvento(endereco, cidade, estado, pais);
            var descricaoEventoValida = ObjectDescricaoEvento.CreateDescricaoEvento(descricaoEvento);
            return new Evento(nomeEventoValido, localEvento, dataInicioEvento, dataFimEvento, descricaoEventoValida);
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

        

        


    }
}
