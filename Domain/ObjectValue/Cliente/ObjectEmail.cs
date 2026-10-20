using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ObjectValue.Cliente
{
    public record ObjectEmail
    {
        public string corpoEmail { get; init; }

        private ObjectEmail(string corpoEmail)
        {
            if (string.IsNullOrWhiteSpace(corpoEmail))
                throw new ArgumentException("O corpo do email não pode ser vazio.", nameof(corpoEmail));
            if (!ValidarEmail(corpoEmail))
                throw new ArgumentException("O corpo do email não é válido.", nameof(corpoEmail));
            this.corpoEmail = corpoEmail;
        }

        public bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regex prático e seguro para o dia a dia
            string padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, padrao, RegexOptions.IgnoreCase);
        }

        public static ObjectEmail CreateEmail(string corpoEmail)
        {
            return new ObjectEmail(corpoEmail);
        }
    }
}
