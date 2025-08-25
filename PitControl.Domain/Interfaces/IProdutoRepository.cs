using PitControl.Domain.Model;

namespace PitControl.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetById(int id);
        Task<Produto> AddProduto(Produto produto);
        Task<Produto> UpdateProduto(Produto Produto);
        Task<Produto> DeleteProduto(int id);
        Task<List<Produto>> GetAll();
    }
}