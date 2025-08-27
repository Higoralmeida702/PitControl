using System.ComponentModel.DataAnnotations;

namespace PitControl.Application.Dto
{
    public class FornecedorDto
    {
        public string NomeFornecedor { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Regiao { get; set; }
    }
}