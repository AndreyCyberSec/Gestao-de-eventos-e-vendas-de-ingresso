using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValue
{
    public record ObjectNome
    {
        public string PrimeiroNome { get; init; }
        public string UltimoNome { get; init; }
        public ObjectNome(string primeiroNome, string ultimoNome)
        {
            if (string.IsNullOrWhiteSpace(primeiroNome))
                throw new ArgumentException("O primeiro nome não pode ser vazio.", nameof(primeiroNome));
            if (string.IsNullOrWhiteSpace(ultimoNome))
                throw new ArgumentException("O último nome não pode ser vazio.", nameof(ultimoNome));
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            
        }
        public static ObjectNome CreateName(string primeiroNome, string ultimoNome)
        {
            return new ObjectNome(primeiroNome, ultimoNome);
        }
    }
}
