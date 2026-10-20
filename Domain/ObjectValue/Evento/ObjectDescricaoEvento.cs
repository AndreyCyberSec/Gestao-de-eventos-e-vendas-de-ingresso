using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValue.Evento
{
    public record ObjectDescricaoEvento
    {
        public string Descricao { get; init; }
        private ObjectDescricaoEvento(string descricao)
        {
            if(!ValidarDescricaoEvento(descricao))
                throw new ArgumentException("A descrição do evento não pode ser nula, vazia ou exceder 500 caracteres.");
            Descricao = descricao;
        }
       
        public bool ValidarDescricaoEvento(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao) || descricao.Length > 500)
                return false;
            
            return true;
        }

        public static ObjectDescricaoEvento CreateDescricaoEvento(string descricao)
        {
            return new ObjectDescricaoEvento(descricao);
        }
    }
}
