using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosFinanceiros.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<T> CriarAsync(T obj);
        Task<T> AtualizarAsync(T obj);
        Task RemoverAsync(long id);
        Task<T> ListarAsync(long id);
        Task<List<T>> ListarTodosAsync();
        Task<T> BuscarPorSiglaAsync(string sigla);
        Task<List<T>> BuscarPorNomeAsync(string nomeAtivo);
        Task<List<T>> BuscarPorSetorAsync(string nomeSetor);
    }
}
