using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValue.Evento
{
    public record ObjectLocalEvento
    {
        public string Endereco { get; init; }
        public string Cidade { get; init; }
        public SiglaEstado Estado { get; init; }
        public string Pais { get; init; }
        public ObjectLocalEvento(string endereco, string cidade, SiglaEstado estado, string pais)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("O endereço não pode ser vazio.", nameof(endereco));
            if (string.IsNullOrWhiteSpace(cidade))
                throw new ArgumentException("A cidade não pode ser vazia.", nameof(cidade));
            if (string.IsNullOrWhiteSpace(pais))
                throw new ArgumentException("O país não pode ser vazio.", nameof(pais));
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }
        public static ObjectLocalEvento CreateLocalEvento(string endereco, string cidade, SiglaEstado estado, string pais)
        {
            return new ObjectLocalEvento(endereco, cidade, estado, pais);
        }
    }
}
