using AtivosFinanceiros.Domain.Entities;
using AtivosFinanceiros.Infra.Context;
using AtivosFinanceiros.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AtivosFinanceiros.Infra.Repositories
{
    public class AcaoRepository : BaseRepository<Acao>, IAcaoRepository
    {
        private readonly AtivosFinanceirosContext _context;

        public AcaoRepository(AtivosFinanceirosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Acao>> BuscarPorNomeAsync(string nomeAcao)
        {
            return await _context.Acoes
                .Where(f => f.NomeDaEmpresa.ToLower().Contains(nomeAcao.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Acao>> BuscarPorSetorAsync(string nomeSetor)
        {
            return await _context.Acoes
                .Where(f => f.Setor.ToLower().Contains(nomeSetor.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Acao> BuscarPorSiglaAsync(string sigla)
        {
            return await _context.Acoes
                .Where(f => f.Sigla.ToUpper().Contains(sigla.ToUpper()))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

    }
}
