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
    public class SalaRepository : ISalaRepository
    {
        private readonly EventoDataBaseContext _context;

        public SalaRepository(EventoDataBaseContext context)
        {
            _context = context;
        }
        public async Task AdicionarSalaAsync(Sala sala)
        {
            await _context.Salas.AddAsync(sala);
            await _context.SaveChangesAsync();
        }

        public Task AtualizarSalaAsync(Sala sala)
        {
            _context.Salas.Update(sala);
            return _context.SaveChangesAsync();
        }

        public async Task<Sala?> ObterSalaPorIdAsync(Guid idSala)
        {
            return await _context.Salas
                .Include(s => s.CadeirasDisponiveis)
                .Include(s => s.Eventos)
                .Include(s => s.Sessoes)
                .FirstOrDefaultAsync(s => s.IdSala == idSala);
        }

        public async Task<Sala?> ObterSalaPorNumeroAsync(int numeroSala)
        {
            return await _context.Salas.FirstOrDefaultAsync(n=> n.NumeroSala == numeroSala);

        }

        public async Task<List<Sala>> ObterTodasSalasAsync()
        {
            return await _context.Salas
                .Include(s=>s.CadeirasDisponiveis)
                .ToListAsync();
        }

        public async Task RemoverSalaAsync(Sala sala)
        {
            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();
        }
    }
}
