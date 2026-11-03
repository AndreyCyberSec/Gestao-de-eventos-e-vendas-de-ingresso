using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Repository
{
    public interface IPagamentoRepository
    {
        Task<Pagamento?> ObterPagamentoPorIdAsync(Guid idPagamento);
        Task<Pagamento?> ObterPagamentoPorDataAsync(DateTime dataPagamento);
        Task<List<Pagamento>> ObterTodosPagamentosAsync();
        Task AdicionarPagamentoAsync(Pagamento pagamento);
        Task AtualizarPagamentoAsync(Pagamento pagamento);
        Task RemoverPagamentoAsync(Pagamento pagamento);
    }
}
