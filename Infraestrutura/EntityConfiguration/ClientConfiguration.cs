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
    public class ClientConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Configuração da entidade Cliente
            //definindo o nome da tabela 
            builder.ToTable("Clientes");
            //definindo a chave primária e não gerada automaticamente porque o IdCliente é do tipo Guid
            //e será gerado automaticamente no momento da criação do objeto Cliente
            builder.HasKey(c => c.IdCliente);
            builder.Property(c => c.IdCliente)
                .ValueGeneratedNever();
            //definindo idade como propriedade obrigatória
            builder.Property(c => c.Idade)
                .IsRequired();
            //definindo os enums
            builder.Property(c => c.TipoDeCliente)
                .HasConversion<string>()
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(c => c.StatusCliente)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();
            //definindo os objetos de valor como propriedades obrigatórias
            builder.OwnsOne(c => c.Nome, n =>
            {
                n.Property(n => n.PrimeiroNome)
                    .HasColumnName("PrimeiroNome")
                    .HasMaxLength(50)
                    .IsRequired();
                n.Property(n => n.UltimoNome)
                    .HasColumnName("UltimoNome")
                    .HasMaxLength(50)
                    .IsRequired();
            });
            builder.OwnsOne(c => c.Email, e =>
            {
                e.Property(e => e.CorpoEmail)
                    .HasColumnName("Email")
                    .HasMaxLength(254)
                    .IsRequired();
                e.HasIndex(e=>e.CorpoEmail)
                    .IsUnique();

            });
            builder.OwnsOne(c => c.Senha, s =>
            {
                s.Property(s => s.Hash)
                    .HasColumnName("Senha")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            

        }
    }
}
