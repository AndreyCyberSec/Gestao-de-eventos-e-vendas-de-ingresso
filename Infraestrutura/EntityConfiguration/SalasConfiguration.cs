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
    public class SalasConfiguration : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("Salas");
            builder.HasKey(s => s.IdSala);
            builder.Property(i=>i.IdSala).ValueGeneratedNever();
            builder.Property(s => s.NumeroSala).IsRequired();
            builder.Property(s => s.Capacidade).IsRequired();
            builder.HasMany(s => s.Sessoes)
                .WithOne(s=>s.Sala)
                .HasForeignKey(s => s.IdSala)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.Eventos)
                 .WithOne(e => e.Sala)
                 .HasForeignKey(e => e.IdSala)
                 .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c=>c.CadeirasDisponiveis)
                .WithOne(c=>c.Sala)
                .HasForeignKey(c => c.IdSala)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(s => s.Status).HasConversion<string>().HasMaxLength(20).IsRequired();
        }
    }
}
