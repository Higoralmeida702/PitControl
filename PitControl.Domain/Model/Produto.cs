
using PitControl.Domain.Enum;
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
        public CategoriaDaPeca CategoriaPeca { get; set; }

        protected Produto() { }

        private string GerarCodigoAleatorio(CategoriaDaPeca categoria, int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            var random = new Random();

            string prefixo = categoria switch
            {
                CategoriaDaPeca.Motor => "MOT",
                CategoriaDaPeca.Transmissao => "TRA",
                CategoriaDaPeca.Suspensao => "SUS",
                CategoriaDaPeca.Freios => "FRE",
                CategoriaDaPeca.EletricaEletronica => "ELE",
                CategoriaDaPeca.Escapamento => "ESC",
                CategoriaDaPeca.Iluminacao => "ILU",
                CategoriaDaPeca.Carroceria => "CAR",
                CategoriaDaPeca.Interior => "INT",
                CategoriaDaPeca.RodasPneus => "ROD",
                CategoriaDaPeca.FiltrosLubrificacao => "FIL"
            };

            var codigoGerado = new string(Enumerable
            .Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)])
            .ToArray());

            return $"{prefixo}-{codigoGerado}";
        }

        public Produto(string nomePeca, CategoriaDaPeca categoria, string fabricante, string localizacaoEstoque, decimal peso, decimal altura, decimal largura, decimal comprimento, DateTime dataDeCadastro, int fornecedorId)
        {
            CategoriaPeca = categoria;
            DataDeCadastro = DateTime.Now;
            Codigo = GerarCodigoAleatorio(categoria);
            ValidateDomain(nomePeca, Codigo, fabricante, localizacaoEstoque, peso, altura, largura, comprimento, dataDeCadastro, fornecedorId);
        }


        public void Update(string nomePeca, string codigo, string fabricante, string localizacaoEstoque, decimal peso, decimal altura, decimal largura, decimal comprimento, DateTime dataDeCadastro, int fornecedorId)
        {
            ValidateDomain(nomePeca, codigo, fabricante, localizacaoEstoque, peso, altura, largura, comprimento, dataDeCadastro, fornecedorId);
        }

        private void ValidateDomain(string nomePeca, string codigo, string fabricante, string localizacaoEstoque, decimal peso, decimal altura, decimal largura, decimal comprimento, DateTime dataDeCadastro, int fornecedorId)
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
            FornecedorId = fornecedorId;
        }
    }

}