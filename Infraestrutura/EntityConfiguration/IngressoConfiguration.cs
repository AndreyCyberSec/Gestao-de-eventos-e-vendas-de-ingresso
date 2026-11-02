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
    public class IngressoConfiguration : IEntityTypeConfiguration<Ingresso>
    {
        public void Configure(EntityTypeBuilder<Ingresso> builder)
        {
            builder.ToTable("Ingressos");
            builder.HasKey(i => i.IdIngresso);
            builder.Property(i => i.IdIngresso)
                    .ValueGeneratedNever();

           builder.OwnsOne(i => i.Preco, p =>
            {
                p.Property(p => p.Valor)
                    .HasColumnName("Preco")
                    .HasPrecision(18,2)
                    .IsRequired();
            });
            builder.Property(i => i.CodigoIngresso)
                    .IsRequired();
            builder.Property(i => i.TipoDeingresso)
                    .HasConversion<string>()
                    .HasMaxLength(15)
                    .IsRequired();
            builder.Property(i => i.Status)
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .IsRequired();

            builder.HasIndex(i => i.CodigoIngresso)
                    .IsUnique();
        }
    }
}
