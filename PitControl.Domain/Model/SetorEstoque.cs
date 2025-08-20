
using PitControl.Domain.Validation;

namespace PitControl.Domain.Model
{
    public class SetorEstoque
    {
        public int Id { get; set; }
        public string NomeSetor { get; set; }
        public ICollection<ProdutoEmEstoque> ProdutosEmEstoque { get; set; } = new List<ProdutoEmEstoque>();

        public SetorEstoque(string nomeSetor)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeSetor), "Nome do setor é obrigatório.");
            NomeSetor = nomeSetor;
        }
    }
}