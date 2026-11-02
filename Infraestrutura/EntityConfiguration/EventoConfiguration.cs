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
    public class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Eventos");
            builder.HasKey(e => e.IdEvento);
            builder.OwnsOne(e => e.NomeEvento, nomeEvento =>
            {
                nomeEvento.Property(n => n.NomeEvento)
                    .HasColumnName("NomeEvento")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            builder.OwnsOne(e => e.Endereco, endereco =>
            {
                endereco.Property(e => e.Endereco)
                    .HasColumnName("Endereco")
                    .HasMaxLength(200)
                    .IsRequired();
                endereco.Property(e => e.Cidade)
                    .HasColumnName("Cidade")
                    .HasMaxLength(100)
                    .IsRequired();
                endereco.Property(e => e.Estado)
                    .HasColumnName("Estado")
                    .HasMaxLength(2)
                    .IsRequired();
                endereco.Property(e => e.Pais)
                    .HasColumnName("Pais")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            builder.Property(e => e.DataInicioEvento)
                .IsRequired();
            builder.Property(e => e.DataFimEvento)
                .IsRequired();
            builder.OwnsOne(builder => builder.DescricaoEvento, descricaoEvento =>
            {
                descricaoEvento.Property(d => d.Descricao)
                    .HasColumnName("DescricaoEvento")
                    .HasMaxLength(500)
                    .IsRequired();
            });

            builder.Property(e => e.StatusEvento)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
