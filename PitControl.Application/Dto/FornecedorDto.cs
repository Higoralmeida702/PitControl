using System.ComponentModel.DataAnnotations;

namespace PitControl.Application.Dto
{
    public class FornecedorDto
    {
        [Required(ErrorMessage = "É necessário o preenchimento do campo informando o nome do fornecedor")]
        public string NomeFornecedor { get; set; }

        [Required(ErrorMessage = "É necessário o preenchimento do campo informando o cnpj")]
        [StringLength(14, ErrorMessage = "Cnpj deve conter 14 caracteres")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "Cnpj deve conter apenas números")]
        public string Cnpj { get; set; }

        [Phone(ErrorMessage = "Número de telefone invalido")]
        [Required(ErrorMessage = "É necessário o preenchimento do campo informando o telefone")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        [Required(ErrorMessage = "É necessário o preenchimento do campo informando o email de contato do fornecedor")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário o preenchimento do campo informando o cep")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP deve conter apenas números")]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Regiao { get; set; }
    }
}