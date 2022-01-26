using AtivosFinanceiros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AtivosFinanceiros.Infra.Mappings
{
    public class FIIMap : IEntityTypeConfiguration<FII>
    {
        public void Configure(EntityTypeBuilder<FII> builder)
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
