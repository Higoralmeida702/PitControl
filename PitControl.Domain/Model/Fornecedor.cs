using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using PitControl.Domain.Validation;

namespace PitControl.Domain.Model
{
    public class Fornecedor
    {
        public int Id { get; private set; }
        public string NomeFornecedor { get; private set; }
        public string Cnpj { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCadastroFornecedor { get; private set; } = DateTime.Now;

        //Dados de Consumo de api para Viacep
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Localidade { get; private set; }
        public string Regiao { get; private set; }

        public Fornecedor(string nomeFornecedor, string cnpj, string telefone, string email, string cep, string logradouro, string bairro, string localidade, string regiao)
        {
            DataCadastroFornecedor = DateTime.Now;
            ValidateDomain(nomeFornecedor, cnpj, telefone, email, cep, logradouro, bairro, localidade, regiao);
        }

        public void Update(string nomeFornecedor, string cnpj, string telefone, string email, string cep, string logradouro, string bairro, string localidade, string regiao)
        {
            ValidateDomain(nomeFornecedor, cnpj, telefone, email, cep, logradouro, bairro, localidade, regiao);
        }

        private void ValidateDomain(string nomeFornecedor, string cnpj, string telefone, string email, string cep, string logradouro, string bairro, string localidade, string regiao)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nomeFornecedor), "Campo inválido - Nome do fornecedor é obrigatório.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(cnpj), "Campo inválido - CNPJ é obrigatório.");
            DomainExceptionValidation.When(cnpj.Length != 14 || !cnpj.All(char.IsDigit), "Campo inválido - CNPJ deve conter exatamente 14 dígitos numéricos.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(telefone), "Campo inválido - Telefone é obrigatório.");
            DomainExceptionValidation.When(telefone.Length < 10 || !telefone.All(char.IsDigit), "Campo inválido - Telefone deve conter apenas números e pelo menos 10 dígitos.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email), "Campo inválido - Email é obrigatório.");
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            DomainExceptionValidation.When(!emailRegex.IsMatch(email), "Campo inválido - Formato de email inválido.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(cep), "Campo inválido - CEP é obrigatório.");
            DomainExceptionValidation.When(cep.Length != 8 || !cep.All(char.IsDigit), "Campo inválido - CEP deve conter exatamente 8 dígitos numéricos.");

            NomeFornecedor = nomeFornecedor;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Localidade = localidade;
            Regiao = regiao;
        }


    }
}