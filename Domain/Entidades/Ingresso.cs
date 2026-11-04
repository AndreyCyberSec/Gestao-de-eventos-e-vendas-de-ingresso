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

        public static Ingresso CreateIngresso(decimal valor, int codigoIngresso, TipoDeIngresso tipoDeingresso)
        {
            var preco = ObjectValor.CreateValor(valor);
            return new Ingresso(preco, codigoIngresso, tipoDeingresso);
        }

        public void AtualizarPreco(decimal valor)
        {
            Preco = ObjectValor.CreateValor(valor);
        }
        public void IngressoIndisponivel()
        {
            Status = StatusDoIngresso.Indisponivel;
        }

        public void CancelarIngresso()
        {
            if (Status == StatusDoIngresso.Cancelado)
                throw new InvalidOperationException(
                    "Este ingresso já está cancelado.");

            if (Status == StatusDoIngresso.Indisponivel)
                throw new InvalidOperationException(
                    "Não é possível cancelar um ingresso que já foi vendido.");

            Status = StatusDoIngresso.Cancelado;
        }

    }
}
