using AtivosFinanceiros.Core.Exceptions;
using AtivosFinanceiros.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosFinanceiros.Domain.Entities
{
    public abstract class Base
    {
        public long Id { get; set; }
        public string Sigla { get; protected set; }
        public string NomeDaEmpresa { get; protected set; }
        public string Setor { get; protected set; }
        public string Descricao { get; protected set; }


        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors => _errors;

        public bool Validate()
        {
            var validator = new BaseValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Algumas campos estão inválidos, corrijá-os para prosseguir." + _errors);
            }

            return true;
        }
    }
}
