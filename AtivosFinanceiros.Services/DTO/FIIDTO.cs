using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosFinanceiros.Services.DTO
{
    public class FIIDTO
    {
        public long Id { get; set; }
        public string Sigla { get; set; }
        public string NomeDaEmpresa { get; set; }
        public string Setor { get; set; }
        public string Descricao { get; set; }

        public FIIDTO()
        {

        }

        public FIIDTO(long id, string sigla, string nomeDaEmpresa, string setor, string descricao)
        {
            Id = id;
            Sigla = sigla;
            NomeDaEmpresa = nomeDaEmpresa;
            Setor = setor;
            Descricao = descricao;
        }
    }
}
