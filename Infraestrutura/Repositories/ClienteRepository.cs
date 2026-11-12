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
    public class ClienteRepository : IClienteRepository
    {
        private readonly EventoDataBaseContext _context;

        public ClienteRepository(EventoDataBaseContext context)
        {
            _context = context;
        }
        public async Task AdicionarClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public  Task AtualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            return Task.CompletedTask;
        }

        public async Task<Cliente?> ObterClientePorEmailAsync(string email)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Email.CorpoEmail == email);
        }

        public async Task<Cliente?> ObterClientePorIdAsync(Guid idCliente)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.IdCliente == idCliente);    
        }

        public async Task<List<Cliente>> ObterTodosClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public Task RemoverCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            return Task.CompletedTask;
        }
    }
}
