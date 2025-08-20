
using PitControl.Domain.Validation;

namespace PitControl.Domain.Model
{
    public class ProdutoEmEstoque
    {
        public int Id { get; private set; }
        
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }

        public int SetorEstoqueId { get; private set; }
        public SetorEstoque SetorEstoque { get; private set; }

        public string CodigoVinculado { get; private set; }
        public decimal QuantidadeAtual { get; private set; }
        public string UnidadeMedida { get; private set; }

        public DateTime DataEntrada { get; private set; }
        public DateTime? DataSaida { get; private set; }
        public string MovidoPara { get; private set; }
        protected ProdutoEmEstoque() { }

        public ProdutoEmEstoque(Produto produto, SetorEstoque setor, string codigoVinculado,
                               decimal quantidade, string unidadeMedida)
        {
            DomainExceptionValidation.When(produto == null, "Produto inválido.");
            DomainExceptionValidation.When(setor == null, "Setor inválido.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(codigoVinculado), "Código vinculado é obrigatório.");
            DomainExceptionValidation.When(quantidade < 0, "Quantidade não pode ser negativa.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(unidadeMedida), "Unidade de medida é obrigatória.");

            Produto = produto;
            ProdutoId = produto.Id;
            SetorEstoque = setor;
            SetorEstoqueId = setor.Id;
            CodigoVinculado = codigoVinculado;
            QuantidadeAtual = quantidade;
            UnidadeMedida = unidadeMedida;
            DataEntrada = DateTime.Now;
        }

        public void MoverProduto(string destino)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(destino), "Destino é obrigatório.");
            MovidoPara = destino;
            DataSaida = DateTime.Now;
        }
    }
}
