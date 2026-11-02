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
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamentos");
            builder.HasKey(p => p.IdPagamento);
            builder.Property(p => p.IdPagamento)
                    .ValueGeneratedNever();

            builder.OwnsOne(p => p.Valor, v =>
            {
                v.Property(v => v.Valor)
                    .HasColumnName("Valor")
                    .HasPrecision(18, 2)
                    .IsRequired();
            });
            builder.Property(builder => builder.DataPagamento)
                    .IsRequired();
            builder.Property(p => p.TipoPagamento)
                    .HasConversion<string>()
                    .HasMaxLength(25)
                    .IsRequired();
            builder.Property(p => p.Status)
                    .HasConversion<string>()
                    .HasMaxLength(20)
                    .IsRequired();
        }
    }
}
