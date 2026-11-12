using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente?> ObterClientePorIdAsync(Guid idCliente);
        Task<Cliente?> ObterClientePorEmailAsync(string email);
        Task<List<Cliente>> ObterTodosClientesAsync();
        Task AdicionarClienteAsync(Cliente cliente);
        Task AtualizarCliente(Cliente cliente);
        Task RemoverCliente(Cliente cliente);
    }
}
