using Aplicacao.Interfaces.Repository;
using Domain.Entidades;
using Infraestrutura.EventDataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly EventoDataBaseContext _context;

        public PagamentoRepository(EventoDataBaseContext context)
        {
            _context = context;
        }
        public async Task AdicionarPagamentoAsync(Pagamento pagamento)
        {
            await _context.Pagamentos.AddAsync(pagamento);
        }

        public  Task AtualizarPagamento(Pagamento pagamento)
        {
           _context.Pagamentos.Update(pagamento);
             return Task.CompletedTask;
        }

        public async Task<Pagamento?> ObterPagamentoPorDataAsync(DateTime dataPagamento)
        {
           return await _context.Pagamentos.FirstOrDefaultAsync(p => p.DataPagamento.Date == dataPagamento.Date);
        }

        public Task<Pagamento?> ObterPagamentoPorIdAsync(Guid idPagamento)
        {
            return _context.Pagamentos.FirstOrDefaultAsync(p => p.IdPagamento == idPagamento);
        }

        public async Task<List<Pagamento>> ObterTodosPagamentosAsync()
        {
           return await _context.Pagamentos.ToListAsync();
        }

        public Task RemoverPagamento(Pagamento pagamento)
        {
            _context.Pagamentos.Remove(pagamento);
             return Task.CompletedTask;
        }
    }
}
