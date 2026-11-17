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
    public class SessaoRepository : ISessaoRepository
    {
        private readonly EventoDataBaseContext _context;

        public SessaoRepository(EventoDataBaseContext context)
        {
            _context = context;
        }

        public async Task AdicionarSessaoAsync(Sessao sessao)
        {
            await _context.Sessoes.AddAsync(sessao);
        }

        public Task AtualizarSessaoAsync(Sessao sessao)
        {
            _context.Sessoes.Update(sessao);
            return Task.CompletedTask;
        }

        public async Task<int> ContarIngressosPorSessaoAsync(Guid idSessao)
        {
            return await _context.Ingressos
                .CountAsync(i => i.IdSessao == idSessao);
        }
        public Task<Sessao?> ObterSessaoPorDataHoraAsync(DateTime dataHora)
        {
            throw new NotImplementedException();
        }

        public async Task<Sessao?> ObterSessaoPorIdAsync(Guid idSessao)
        {
            return await _context.Sessoes
               .Include(s => s.Sala)
               .Include(s => s.Evento)
               .FirstOrDefaultAsync(s => s.IdSessao == idSessao);
        }

        public async Task<List<Sessao>> ObterTodasSessoesAsync()
        {
            return await _context.Sessoes
                .Include(s => s.Sala)
                .Include(s => s.Evento)
                .ToListAsync();
        }

        public Task RemoverSessaoAsync(Sessao sessao)
        {
            _context.Sessoes.Remove(sessao);
            return Task.CompletedTask;
        }
    }
}
