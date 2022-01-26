using AtivosFinanceiros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosFinanceiros.Infra.Interfaces
{
    public interface IAcaoRepository : IBaseRepository<Acao>
    {
        Task<Acao> BuscarPorSiglaAsync(string sigla);
        Task<List<Acao>> BuscarPorNomeAsync(string nomeAcao);
        Task<List<Acao>> BuscarPorSetorAsync(string nomeSetor);
    }
}
