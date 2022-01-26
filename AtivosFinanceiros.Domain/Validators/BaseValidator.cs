using AtivosFinanceiros.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosFinanceiros.Domain.Validators
{
    public class BaseValidator : AbstractValidator<Base>
    {
        public BaseValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Sigla)
                .NotEmpty()
                .WithMessage("Sigla não pode ser vazia.")

                .NotNull()
                .WithMessage("Sigla não pode ser nula.")

                .Length(5,6)
                .WithMessage("Sigla deve ter no minímo 5 e máximo 6 caracteres.");

            RuleFor(x => x.NomeDaEmpresa)
                .NotEmpty()
                .WithMessage("Nome da Empresa não pode ser vazia.")

                .NotNull()
                .WithMessage("Nome da Empresa não pode ser nula.")

                .Length(8, 60)
                .WithMessage("Nome da Empresa deve ter no minímo 8 e máximo 60 caracteres.");

            RuleFor(x => x.Setor)
                .NotEmpty()
                .WithMessage("Setor não pode ser vazia.")

                .NotNull()
                .WithMessage("Setor não pode ser nula.")

                .Length(5, 60)
                .WithMessage("Setor deve ter no minímo 5 e máximo 60 caracteres.");

            RuleFor(x => x.Descricao)
                .MaximumLength(255)
                .WithMessage("Descrição deve ter no máximo 255 caracteres.");
        }
    }
}
