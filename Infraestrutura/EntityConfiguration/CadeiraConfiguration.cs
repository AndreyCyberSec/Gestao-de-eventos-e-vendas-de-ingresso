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
    public class CadeiraConfiguration : IEntityTypeConfiguration<Cadeira>
    {
        public void Configure(EntityTypeBuilder<Cadeira> builder)
        {
            builder.ToTable("Cadeiras");
            builder.HasKey(c => c.IdCadeira);
            builder.Property(c => c.IdCadeira)
                    .ValueGeneratedNever();
           builder.Property(n=> n.NumeroCadeira)
                    .IsRequired()
                    .HasMaxLength(10);
            builder.Property(s => s.Status)
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .IsRequired();
        }
    }
}
