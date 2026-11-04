using Aplicacao.Interfaces.Repository;
using Domain.Entidades;
using Domain.Enum;
using Infraestrutura.EventDataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories
{
    public class IngressoRepository : IIngressoRepository
    {
        private readonly EventoDataBaseContext _context;

        public IngressoRepository(EventoDataBaseContext context)
        {
            _context = context;
        }
        public async Task AdicionarIngressoAsync(Ingresso ingresso)
        {
            await  _context.Ingressos.AddAsync(ingresso);
            await _context.SaveChangesAsync();
        }

        public Task AtualizarIngresso(Ingresso ingresso)
        {
            _context.Ingressos.Update(ingresso);
            return Task.CompletedTask;
        }

        public async Task<Ingresso?> ObterIngressoPorCodigoAsync(int codigoIngresso)
        {
            return await _context.Ingressos.FirstOrDefaultAsync(i => i.CodigoIngresso == codigoIngresso);
        }

        public async Task<Ingresso?> ObterIngressoPorIdAsync(Guid idIngresso)
        {
            return await _context.Ingressos.FirstOrDefaultAsync(i => i.IdIngresso == idIngresso);
        }

        public async Task<List<Ingresso>> ObterTodosIngressosAsync()
        {
            return await _context.Ingressos.ToListAsync();
        }

        public async Task<bool> PossuiPagamentoAsync(Guid idIngresso)
        {
            return await _context.Pagamentos
       .AnyAsync(p => p.Idingresso == idIngresso);
        }

        public async Task<bool> PossuiPagamentoPendenteAsync(Guid idIngresso)
        {
            return await _context.Pagamentos.AnyAsync(p =>
       p.Idingresso == idIngresso &&
       p.Status == StatusPagamento.Pendente);
        }

        public Task RemoverIngresso(Ingresso ingresso)
        {
            _context.Ingressos.Remove(ingresso);
            return Task.CompletedTask;
        }
    }
}
