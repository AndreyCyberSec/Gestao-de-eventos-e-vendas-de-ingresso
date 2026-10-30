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
        private ObjectValor(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("O valor não pode ser negativo.");
          

            Valor = valor;
            
        }

        public static ObjectValor CreateValor(decimal valor)
        {
            return new ObjectValor(valor);
        }
    }
}
