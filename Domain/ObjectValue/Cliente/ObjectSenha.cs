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
        public string Senha { get; init; }
        private ObjectSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("A senha não pode ser vazia.", nameof(senha));
            if (!ValidarSenha(senha))
                throw new ArgumentException("A senha não é válida. Ela deve ter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas e números.", nameof(senha));
            Senha = senha;
        }
        public bool ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                return false;
            // Regex para validar a senha
            string padrao = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            return Regex.IsMatch(senha, padrao);
        }

        public static ObjectSenha CreateSenha(string senha)
        {
            return new ObjectSenha(senha);
        }
    }
}
