using System.ComponentModel.DataAnnotations;
using PitControl.Domain.Validation;

namespace PitControl.Domain.Model
{
    public class Fornecedor
    {
        public int Id { get; private set; }
        public string NomeFornecedor { get; private set; }
        public string Cnpj { get; private set; }
        [Phone]
        public string Telefone { get; private set; }
        [EmailAddress]
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
            ValidateDomain(nomeFornecedor, cnpj, telefone, email, cep, logradouro, bairro, localidade, regiao);
        }

        public void Update(string nomeFornecedor, string cnpj, string telefone, string email, string cep, string logradouro, string bairro, string localidade, string regiao)
        {
            ValidateDomain(nomeFornecedor, cnpj, telefone, email, cep, logradouro, bairro, localidade, regiao);
        }
        private void ValidateDomain(string nomeFornecedor, string cnpj, string telefone, string email, string cep, string logradouro, string bairro, string localidade, string regiao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeFornecedor), "Campo invalido - Nome do fornecedor é solicitado");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cnpj), "Campo invalido - Cnpj do fornecedor é solicitado");
            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "Campo invalido - Telefone do fornecedor é solicitado");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Campo invalido - Email do fornecedor é solicitado");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cep), "Campo invalido - CEP é solicitado");


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