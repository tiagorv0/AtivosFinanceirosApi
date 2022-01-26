using AtivosFinanceiros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosFinanceiros.Infra.Interfaces
{
    public interface IFIIRepository : IBaseRepository<FII>
    {
        Task<FII> BuscarPorSiglaAsync(string sigla);
        Task<List<FII>> BuscarPorNomeAsync(string nomeAcao);
        Task<List<FII>> BuscarPorSetorAsync(string nomeSetor);
    }
}
