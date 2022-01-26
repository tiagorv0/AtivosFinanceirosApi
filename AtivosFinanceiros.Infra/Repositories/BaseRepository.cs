using AtivosFinanceiros.Domain.Entities;
using AtivosFinanceiros.Infra.Context;
using AtivosFinanceiros.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosFinanceiros.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly AtivosFinanceirosContext _context;

        public BaseRepository(AtivosFinanceirosContext context)
        {
            _context = context;
        }

        public async Task<T> AtualizarAsync(T obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<T> CriarAsync(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<T> ListarAsync(long id)
        {
            var obj = await _context.Set<T>()
                                .AsNoTracking()
                                .Where(t => t.Id == id)
                                .ToListAsync();

            return obj.FirstOrDefault();
            
        }

        public async Task<List<T>> ListarTodosAsync()
        {
            return await _context.Set<T>()
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task RemoverAsync(long id)
        {
            var obj = await ListarAsync(id);

            if(obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}
