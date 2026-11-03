using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Repository
{
    public interface IIngressoRepository
    {
        Task<Ingresso?> ObterIngressoPorIdAsync(Guid idIngresso);
        Task<Ingresso?> ObterIngressoPorCodigoAsync(int codigoIngresso);
        Task<List<Ingresso>> ObterTodosIngressosAsync();
        Task AdicionarIngressoAsync(Ingresso ingresso);
        Task AtualizarIngressoAsync(Ingresso ingresso);
        Task RemoverIngressoAsync(Ingresso ingresso);
    }
}
