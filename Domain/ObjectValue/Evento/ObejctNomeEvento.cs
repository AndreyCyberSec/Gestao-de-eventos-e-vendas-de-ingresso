using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ObjectValue.Evento
{
    public record ObejctNomeEvento
    {
        public string NomeEvento { get; init; }

        private ObejctNomeEvento(string nomeEvento)
        {
            if (string.IsNullOrWhiteSpace(nomeEvento))
                throw new ArgumentException("O nome do evento não pode ser vazio.", nameof(nomeEvento));
            if (ValidarNomeEvento(nomeEvento))
            {
                throw new ArgumentException("O nome do evento não é válido. Deve conter apenas letras.", nameof(nomeEvento));
            }
                NomeEvento = nomeEvento;
        }

        public bool ValidarNomeEvento(string nomeEvento)
        {
            if (string.IsNullOrWhiteSpace(nomeEvento))
                return false;
            // Regex prático e seguro para o dia a dia
            string pattern = @"^\p{L}+$";
            return Regex.IsMatch(nomeEvento, pattern, RegexOptions.IgnoreCase);
        }

        public static ObejctNomeEvento CreateNomeEvento(string nomeEvento)
        {
            return new ObejctNomeEvento(nomeEvento);
        }
    }
}
