using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Repository
{
    public interface IEventoRepository
    {
        Task<Evento?> ObterEventoPorIdAsync(Guid idEvento);
        Task<Evento?> ObterEventoPorNomeAsync(string nomeEvento);
        Task<List<Evento>> ObterTodosEventosAsync();
        Task AdicionarEventoAsync(Evento evento);
        Task AtualizarEventoAsync(Evento evento);
        Task RemoverEventoAsync(Evento evento);
    }
}
