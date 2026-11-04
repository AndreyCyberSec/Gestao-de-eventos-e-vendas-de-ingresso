using Aplicacao.DTOs.IngressosDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Services
{
    public interface IIngressoService
    {
        Task<RespostaIngresso> CadastrarIngressoAsync(CadastrarIngresso ingressoDto);
        Task<RespostaIngresso> AtualizarIngressoAsync(ModificarIngresso ingressoDto);
    }
}
