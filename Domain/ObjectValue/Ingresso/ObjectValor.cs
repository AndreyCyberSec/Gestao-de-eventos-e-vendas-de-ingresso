using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValue.Ingresso
{
    public record ObjectValor
    {
        public decimal Valor { get; private set; }
        public decimal Quantidade { get; private set; }
        private ObjectValor(decimal valor, decimal quantidade)
        {
            if (valor < 0)
                throw new ArgumentException("O valor não pode ser negativo.");
            if(quantidade < 0)
                throw new ArgumentException("A quantidade não pode ser negativa.");

            Valor = valor;
            Quantidade = quantidade;
        }

        public static ObjectValor CreateValor(decimal valor, decimal quantidade)
        {
            return new ObjectValor(valor, quantidade);
        }
    }
}
