using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ObjectValue.Cliente
{
     public record ObjectSenha
    {
        public string Hash { get; init; }
        private ObjectSenha(string hash)
        {
            if (string.IsNullOrWhiteSpace(hash))
                throw new ArgumentException("A senha não pode ser vazia.", nameof(hash));
            if (!ValidarSenha(hash))
                throw new ArgumentException("A senha não é válida. Ela deve ter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas e números.", nameof(hash));
            Hash = hash;
        }
        public bool ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                return false;
            // Regex para validar a senha
            string padrao = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            return Regex.IsMatch(senha, padrao);
        }

        public static ObjectSenha CriarComHash(string hash)
        {
            return new ObjectSenha(hash);
        }
    }
}
