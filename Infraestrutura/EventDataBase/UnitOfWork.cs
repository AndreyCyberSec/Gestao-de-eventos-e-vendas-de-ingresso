using Aplicacao.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.EventDataBase
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly EventoDataBaseContext _context;

        public UnitOfWork(EventoDataBaseContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
