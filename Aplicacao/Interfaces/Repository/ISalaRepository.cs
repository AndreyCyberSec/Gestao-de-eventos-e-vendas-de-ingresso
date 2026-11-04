using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Repository
{
    public interface ISalaRepository
    {
        Task<Sala?> ObterSalaPorIdAsync(Guid idSala);
        Task<Sala?> ObterSalaPorNumeroAsync(int numeroSala);
        Task<List<Sala>> ObterTodasSalasAsync();
        Task AdicionarSalaAsync(Sala sala);
        Task AtualizarSalaAsync(Sala sala);
        Task RemoverSalaAsync(Sala sala);
    }
}
