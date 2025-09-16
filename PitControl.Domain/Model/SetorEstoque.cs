
using PitControl.Domain.Validation;

namespace PitControl.Domain.Model
{
    public class SetorEstoque
    {
        public int Id { get; private set; }
        public string NomeSetor { get; private set; }
        public string Corredor { get; private set; }
        public string Posicao { get; private set; }
        public ICollection<ProdutoEmEstoque> ProdutosEmEstoque { get; set; } = new List<ProdutoEmEstoque>();


        public SetorEstoque(string nomeSetor, string corredor, string posicao)
        {
            ValidateDomain(nomeSetor, corredor, posicao);
        }

        private void ValidateDomain(string nomeSetor, string corredor, string posicao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeSetor), "Nome do setor é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(corredor), "Corredor é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(posicao), "Posição é obrigatória.");

            NomeSetor = nomeSetor;
            Corredor = corredor;
            Posicao = posicao;
        }

        public void Update(string nomeSetor, string corredor, string posicao)
        {
            ValidateDomain(nomeSetor, corredor, posicao);
        }
    }
}