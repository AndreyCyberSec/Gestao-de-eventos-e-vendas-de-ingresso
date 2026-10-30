using Domain.ObjectValue.Ingresso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValue.Pagamento
{
    public class ObjectDinheiro
    {
        public decimal Valor { get; private set; }
        private ObjectDinheiro(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("O valor não pode ser negativo.");


            Valor = valor;

        }

        public static ObjectDinheiro CreateValor(decimal valor)
        {
            return new ObjectDinheiro(valor);
        }
    }
}
