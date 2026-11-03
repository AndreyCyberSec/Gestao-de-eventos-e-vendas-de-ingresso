using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Repository
{
    public interface ICadeiraRepository
    {
        //implementar os métodos de acesso a dados para a entidade Cadeira
        Task<Cadeira?> BuscarCadeirasIdAsync(Guid idCadeira);
        Task<Cadeira?> BuscarCadeirasNumeroAsync(string numero);
        Task<List<Cadeira>> TodasCadeirasAsync();
        Task AdicionarCadeiraAsync(Cadeira cadeira);
        Task AtualizarCadeiraAsync(Cadeira cadeira);
        Task RemoverCadeiraAsync(Cadeira cadeira);
    }
}
