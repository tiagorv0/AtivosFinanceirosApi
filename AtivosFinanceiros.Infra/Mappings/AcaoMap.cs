using AtivosFinanceiros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosFinanceiros.Infra.Mappings
{
    public class AcaoMap : IEntityTypeConfiguration<Acao>
    {
        public void Configure(EntityTypeBuilder<Acao> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(f => f.Sigla)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnType("VARCHAR(6)");

            builder.Property(f => f.NomeDaEmpresa)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("VARCHAR(60)");

            builder.Property(f => f.Setor)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("VARCHAR(60)");

            builder.Property(f => f.Descricao)
                .HasMaxLength(255)
                .HasColumnType("VARCHAR(255)");
        }
    }
}
