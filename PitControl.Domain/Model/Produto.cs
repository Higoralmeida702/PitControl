using PitControl.Domain.Validation;

namespace PitControl.Domain.Model
{
    public class Produto
    {
        public int Id { get; private set; }
        public string NomePeca { get; private set; }
        public string Codigo { get; private set; }
        public string Fabricante { get; private set; }
        public string LocalizacaoEstoque { get; private set; }
        public decimal Peso { get; private set; }
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Comprimento { get; private set; }
        public DateTime DataDeCadastro { get; private set; }
        public Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }

        private string GerarCodigoAleatorio(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            var random = new Random();

            var codigoGerado = new string(Enumerable
            .Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)])
            .ToArray());
            return $"PRD-{codigoGerado}";
        }

        public Produto(string nomePeca, string codigo, string fabricante, string localizacaoEstoque, decimal peso, decimal altura, decimal largura, decimal comprimento, DateTime dataDeCadastro, Fornecedor fornecedor, int fornecedorId)
        {
            DataDeCadastro = DateTime.Now;
            Codigo = GerarCodigoAleatorio();
            ValidateDomain(nomePeca, codigo, fabricante, localizacaoEstoque, peso, altura, largura, comprimento, dataDeCadastro, fornecedor, fornecedorId);
        }

        public void Update(string nomePeca, string codigo, string fabricante, string localizacaoEstoque, decimal peso, decimal altura, decimal largura, decimal comprimento, DateTime dataDeCadastro, Fornecedor fornecedor, int fornecedorId)
        {
            ValidateDomain(nomePeca, codigo, fabricante, localizacaoEstoque, peso, altura, largura, comprimento, dataDeCadastro, fornecedor, fornecedorId);
        }

        private void ValidateDomain(string nomePeca, string codigo, string fabricante, string localizacaoEstoque, decimal peso, decimal altura, decimal largura, decimal comprimento, DateTime dataDeCadastro, Fornecedor fornecedor, int fornecedorId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomePeca), "Nome da peça é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(fabricante), "Fabricante é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(localizacaoEstoque), "Localização no estoque é obrigatória");
            DomainExceptionValidation.When(peso <= 0, "Peso deve ser maior que zero.");
            DomainExceptionValidation.When(altura <= 0, "Altura deve ser maior que zero.");
            DomainExceptionValidation.When(largura <= 0, "Largura deve ser maior que zero.");
            DomainExceptionValidation.When(comprimento <= 0, "Comprimento deve ser maior que zero.");

            NomePeca = nomePeca;
            Codigo = codigo;
            Fabricante = fabricante;
            LocalizacaoEstoque = localizacaoEstoque;
            Peso = peso;
            Altura = altura;
            Largura = largura;
            Comprimento = comprimento;
            DataDeCadastro = dataDeCadastro;
            Fornecedor = fornecedor;
            FornecedorId = fornecedorId;
        }
    }

}