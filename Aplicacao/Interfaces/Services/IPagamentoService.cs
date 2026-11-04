using Aplicacao.DTOs.PagamentosDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Services
{
    public interface IPagamentoService
    {
        Task<RespostaPagamento> CadastrarPagamentoAsync(CadastrarPagamento pagamentoDto);

        Task<RespostaPagamento> AprovarPagamentoAsync(Guid idPagamento);

        Task<RespostaPagamento> ReprovarPagamentoAsync(Guid idPagamento);

    }
}
