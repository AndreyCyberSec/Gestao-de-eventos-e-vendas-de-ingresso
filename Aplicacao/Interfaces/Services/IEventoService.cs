using Aplicacao.DTOs.EventosDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Services
{
     public  interface IEventoService
    {
        Task<RespostaEvento> CadastrarEventoAsync(CadastrarEvento eventoDto);
        Task<RespostaEvento> AtualizarEventoAsync(ModificarEvento eventoDto);
    }
}
