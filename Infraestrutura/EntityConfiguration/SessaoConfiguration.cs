using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.EntityConfiguration
{
    public class SessaoConfiguration : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder.ToTable("Sessoes");
            builder.HasKey(s => s.IdSessao);
            builder.Property(i=> i.IdSessao).ValueGeneratedNever();
            builder.HasOne(s => s.Evento)
                .WithMany(e => e.Sessoes)
                .HasForeignKey(s => s.IdEvento)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Sala)
                .WithMany(s => s.Sessoes)
                .HasForeignKey(s => s.IdSala)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
