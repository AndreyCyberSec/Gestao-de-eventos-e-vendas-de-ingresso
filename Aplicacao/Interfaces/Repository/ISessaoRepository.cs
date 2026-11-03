using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Repository
{
    public interface ISessaoRepository
    {
        Task<Sessao?> ObterSessaoPorIdAsync(Guid idSessao);
        Task<Sessao?> ObterSessaoPorDataHoraAsync(DateTime dataHora);
        Task<List<Sessao>> ObterTodasSessoesAsync();
        Task AdicionarSessaoAsync(Sessao sessao);
        Task AtualizarSessaoAsync(Sessao sessao);
        Task RemoverSessaoAsync(Sessao sessao);
    }
}
