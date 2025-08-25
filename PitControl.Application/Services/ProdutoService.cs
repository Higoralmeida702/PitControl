using PitControl.Application.Common;
using PitControl.Application.Dto;
using PitControl.Application.Interfaces;
using PitControl.Domain.Interfaces;
using PitControl.Domain.Model;

namespace PitControl.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Resposta<Produto>> AddProduto(ProdutoDto produtoDto)
        {
            var produto = new Produto
            (
                produtoDto.NomePeca,
                produtoDto.CategoriaPeca,
                produtoDto.Fabricante,
                produtoDto.LocalizacaoEstoque,
                produtoDto.Peso,
                produtoDto.Altura,
                produtoDto.Largura,
                produtoDto.Comprimento,
                produtoDto.DataDeCadastro,
                produtoDto.FornecedorId
            );

            var resultado = await _produtoRepository.AddProduto(produto);
            return new Resposta<Produto>(produto, "Produto adicionado com sucesso");
        }

        public async Task<Resposta<Produto>> DeleteProduto(int id)
        {
            var produto = await _produtoRepository.GetById(id);

            if (produto == null)
            {
                return new Resposta<Produto>(null, "Produto não encontrado", false);
            }

            await _produtoRepository.DeleteProduto(id);
            return new Resposta<Produto>(produto, "Produto excluido com sucesso");
        }

        public async Task<Resposta<List<Produto>>> GetAll()
        {
            var produtos = await _produtoRepository.GetAll();
            return new Resposta<List<Produto>>(produtos, "Produtos obtidos com sucesso");
        }

        public async Task<Resposta<Produto>> GetById(int id)
        {
            var produtoId = await _produtoRepository.GetById(id);
            if (produtoId == null)
            {
                return new Resposta<Produto>(null, "Produto não encontrado", false);
            }

            await _produtoRepository.GetById(id);
            return new Resposta<Produto>(produtoId, "Produto obtido com sucesso");
        }

        public async Task<Resposta<Produto>> UpdateProduto(int id, ProdutoDto produtoDto)
        {
            var produto = await _produtoRepository.GetById(id);

            if (produto == null)
            {
                return new Resposta<Produto>(null, "Produto não encontrado", false);
            }

            produto.Update
            (
                produtoDto.NomePeca,
                produtoDto.Fabricante,
                produtoDto.LocalizacaoEstoque,
                produtoDto.Peso,
                produtoDto.Altura,
                produtoDto.Largura,
                produtoDto.Comprimento,
                produtoDto.DataDeCadastro,
                produtoDto.FornecedorId
            );

            await _produtoRepository.UpdateProduto(produto);

            return new Resposta<Produto>(produto, "Produto atualizado com sucesso");
        }


    }
}