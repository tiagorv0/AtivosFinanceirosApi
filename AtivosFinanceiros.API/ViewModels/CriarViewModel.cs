using System.ComponentModel.DataAnnotations;

namespace AtivosFinanceiros.API.ViewModels
{
    public class CriarViewModel
    {
        [Required(ErrorMessage = "{0} não pode ser nula.")]
        [StringLength(6, MinimumLength = 5, ErrorMessage = "A {0} deve ter no minimo {2} caracteres e máximo de {1}")]
        public string Sigla { get; set; }


        [Required(ErrorMessage = "Nome da Empresa não pode ser nula.")]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "Nome da Empresa deve ter no minimo {2} caracteres e máximo de {1}")]
        public string NomeDaEmpresa { get; set; }


        [Required(ErrorMessage = "{0} não pode ser nula.")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "{0} deve ter no minimo {2} caracteres e máximo de {1}")]
        public string Setor { get; set; }


        [StringLength(255, MinimumLength = 0, ErrorMessage = "Descrição deve ter no minimo {2} caracteres e máximo de {1}")]
        public string Descricao { get; set; }
    }
}
