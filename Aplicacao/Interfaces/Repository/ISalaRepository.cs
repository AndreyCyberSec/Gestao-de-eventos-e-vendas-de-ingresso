using Domain.Entidades;
using Domain.Enum;
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

        Task<Sala?> ObterStatusSalaDisponivelAsync(StatusSala  status = StatusSala.Disponivel);

        Task<Sala?> ObterStatusSalaIndisponivelAsync(StatusSala status = StatusSala.Indisponivel);
        Task<List<Sala>> ObterTodasSalasAsync();
        Task AdicionarSalaAsync(Sala sala);
        Task AtualizarSalaAsync(Sala sala);
        Task RemoverSalaAsync(Sala sala);
    }
}
