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
    public class FIIRepository : BaseRepository<FII>, IFIIRepository
    {
        private readonly AtivosFinanceirosContext _context;

        public FIIRepository(AtivosFinanceirosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<FII>> BuscarPorNomeAsync(string nomeAcao)
        {
            return await _context.FIIs
                .Where(f => f.NomeDaEmpresa.ToLower().Contains(nomeAcao.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<FII>> BuscarPorSetorAsync(string nomeSetor)
        {
            return await _context.FIIs
                .Where(f => f.Setor.ToLower().Contains(nomeSetor.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<FII> BuscarPorSiglaAsync(string sigla)
        {
            return await _context.FIIs
                .Where(f => f.Sigla.ToUpper().Contains(sigla.ToUpper()))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

    }
}
