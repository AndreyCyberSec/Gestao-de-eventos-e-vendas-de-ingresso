using Aplicacao.DTOs.ClientesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Services
{
    public interface IClienteService
    {
        Task<RespostaCliente> CadastrarClienteAsync(CadastrarCliente clienteDto);
        Task<RespostaCliente> AtualizarClienteAsync(ModificarCliente clienteDto);

        Task RemoverClienteAsync(Guid Id);

    }
}
