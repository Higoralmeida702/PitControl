using System.ComponentModel.DataAnnotations;
using PitControl.Domain.Enum;
using PitControl.Domain.Model;

namespace PitControl.Application.Dto
{
    public class ProdutoDto
    {
        [Required(ErrorMessage = "É necessário o preenchimento do campo informando o nome da peça")]
        public string NomePeca { get;  set; }

        [Required(ErrorMessage = "É necessário o preenchimento do campo informando o fabricante da peça")]
        public string Fabricante { get;  set; }

        [Required(ErrorMessage = "É necessário o preenchimento do campo informando a localização da peça no estoque")]
        public string LocalizacaoEstoque { get;  set; }

        [Required(ErrorMessage = "É necessário o preenchimento do campo informando o peso da peça")]
        public decimal Peso { get;  set; }

        [Required(ErrorMessage = "É necessário o preenchimento do campo informando a altura da peça")]
        public decimal Altura { get;  set; }

        [Required(ErrorMessage = "É necessário o preenchimento do campo informando a largura da peça")]
        public decimal Largura { get;  set; }

        [Required(ErrorMessage = "É necessário o preenchimento do campo informando o comprimento da peça")]
        public decimal Comprimento { get;  set; }

        [Required(ErrorMessage = "É necessário o preenchimento do campo informando o fornecedor da peça")]
        public int FornecedorId { get; set; }
        public CategoriaDaPeca CategoriaPeca { get; set; }
    }
}
