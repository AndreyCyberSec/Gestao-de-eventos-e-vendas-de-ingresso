using Aplicacao.DTOs.SessoesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Services
{
    public interface ISessaoService
    {
        Task<RespostaSessao> CadastrarSessaoAsync(CadastrarSessao sessaoDto);

        Task<RespostaSessao?> BuscarSessaoPorIdAsync(Guid id);

        Task<List<RespostaSessao>> ListarSessoesAsync();

        Task AtualizarSessaoAsync(Guid id, CadastrarSessao sessaoDto);

        Task CancelarSessaoAsync(Guid id);

        Task<bool> VerificarDisponibilidadeAsync(Guid id);
    }
}
