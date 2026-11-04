using Aplicacao.DTOs.SalasDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Services
{
    public interface ISalaService
    {
        Task<RespostaSala> CadastrarSalaAsync(CadastrarSala salaDto);
        Task<RespostaSala> AtualizarSalaAsync(ModificarSala salaDto);
    }

}
