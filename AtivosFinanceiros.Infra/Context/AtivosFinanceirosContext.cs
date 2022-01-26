using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtivosFinanceiros.Domain.Entities;
using AtivosFinanceiros.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AtivosFinanceiros.Infra.Context
{
    public class AtivosFinanceirosContext : DbContext
    {
        public AtivosFinanceirosContext()
        {

        }

        public AtivosFinanceirosContext(DbContextOptions<AtivosFinanceirosContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer(@"Data Source=DESKTOP-ONMGS4I;Database=AtivosFinanceiros;Integrated Security=SSPI");
        //}

        public virtual DbSet<Acao> Acoes { get; set; }
        public virtual DbSet<FII> FIIs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcaoMap());
            modelBuilder.ApplyConfiguration(new FIIMap());
        }
    }
}
