using PitControl.Domain.Enum;

namespace PitControl.Application.Dto
{
    public class ProdutoDto
    {
        public string NomePeca { get; set; }
        public string Fabricante { get; set; }
        public string LocalizacaoEstoque { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal Comprimento { get; set; }
        public DateTime DataDeCadastro { get; set; } = DateTime.Now;
        public int FornecedorId { get; set; }
        public CategoriaDaPeca CategoriaPeca { get; set; }
    }
}
