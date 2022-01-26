using AtivosFinanceiros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosFinanceiros.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> CriarAsync(T obj);
        Task<T> AtualizarAsync(T obj);
        Task RemoverAsync(long id);
        Task<T> ListarAsync(long id);
        Task<List<T>> ListarTodosAsync();
    }
}
