using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosFinanceiros.Domain.Entities
{
    public class Acao : Base
    {

        protected Acao()
        {
            
        }

        public Acao(long id, string sigla, string nomeDaEmpresa, string setor, string descricao)
        {
            Id = id;
            Sigla = sigla.ToUpper();
            NomeDaEmpresa = nomeDaEmpresa;
            Setor = setor;
            Descricao = descricao;

            _errors = new List<string>();

            Validate();
        }


    }
}
