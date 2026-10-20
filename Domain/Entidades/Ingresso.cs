using Domain.Enum;
using Domain.ObjectValue.Ingresso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Ingresso
    {
        public Guid IdIngresso { get; private set; }
        public ObjectValor Preco { get; private set; }
        public int CodigoIngresso { get; private set; }
        public TipoDeIngresso TipoDeingresso { get; private set; }
        public StatusDoIngresso Status { get; private set; }

        protected Ingresso() { }

        private Ingresso(ObjectValor preco, int codigoIngresso, TipoDeIngresso tipoDeingresso)
        {
            IdIngresso = Guid.NewGuid();
            Preco = preco;
            CodigoIngresso = codigoIngresso;
            TipoDeingresso = tipoDeingresso;
            Status = StatusDoIngresso.Disponivel;
        }

        public static Ingresso CreateIngresso(decimal valor,decimal quantidade, int codigoIngresso, TipoDeIngresso tipoDeingresso)
        {
            var preco = ObjectValor.CreateValor(valor, quantidade);
            return new Ingresso(preco, codigoIngresso, tipoDeingresso);
        }

        public void AtualizarPreco(decimal valor, decimal quantidade)
        {
            Preco = ObjectValor.CreateValor(valor, quantidade);
        }
        public void Multiplicar(int fator)
        {
            if (fator < 0)
                throw new ArgumentException("O fator de multiplicação não pode ser negativo.");
            Preco = ObjectValor.CreateValor(Preco.Valor * fator, Preco.Quantidade * fator);
        }
        public void IngressoIndisponivel()
        {
            Status = StatusDoIngresso.Indisponivel;
        }
    }
}
