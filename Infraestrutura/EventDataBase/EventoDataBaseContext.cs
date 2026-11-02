using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.EventDataBase
{
    public class EventoDataBaseContext : DbContext
    {
        public EventoDataBaseContext(DbContextOptions<EventoDataBaseContext> options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Ingresso> Ingressos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cadeira> Cadeiras { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }

        //fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

    }
}
