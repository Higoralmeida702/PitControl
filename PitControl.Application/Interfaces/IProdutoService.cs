using PitControl.Application.Common;
using PitControl.Application.Dto;
using PitControl.Domain.Model;

namespace PitControl.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<Resposta<Produto>> GetById(int id);
        Task<Resposta<Produto>> AddProduto(ProdutoDto produtoDto);
        Task<Resposta<Produto>> UpdateProduto(int id, ProdutoDto produtodto);
        Task<Resposta<Produto>> DeleteProduto(int id);
        Task<Resposta<List<Produto>>> GetAll();
    }
}