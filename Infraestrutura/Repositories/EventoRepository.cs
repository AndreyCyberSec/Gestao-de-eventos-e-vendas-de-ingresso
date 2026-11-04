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
    public class EventoRepository : IEventoRepository
    {
        private readonly EventoDataBaseContext _context;

        public EventoRepository(EventoDataBaseContext context)
        {
            _context = context;
        }

        public async Task AdicionarEventoAsync(Evento evento)
        {
            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarEventoAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }

        public async Task<Evento?> ObterEventoPorIdAsync(Guid idEvento)
        {
            return await _context.Eventos
                .Include(e => e.Sala.NumeroSala)
                .FirstOrDefaultAsync(e => e.IdEvento == idEvento);
        }

        public async Task<Evento?> ObterEventoPorNomeAsync(string nomeEvento)
        {
            return await _context.Eventos.FirstOrDefaultAsync(e => e.NomeEvento.NomeEvento == nomeEvento);
        }

        public async Task<List<Evento>> ObterTodosEventosAsync()
        {
            return await _context.Eventos
                .Include(e => e.Sala.NumeroSala)
                .ToListAsync();
        }

        public async Task RemoverEventoAsync(Evento evento)
        {
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
        }
    }
}
