using Microsoft.EntityFrameworkCore;
using PitControl.Domain.Interfaces;
using PitControl.Domain.Model;
using PitControl.Infra.Data.Data;

namespace PitControl.Infra.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> AddProduto(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;

        }

        public async Task<Produto> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                throw new Exception("celular nao encontrado");
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }
            return produto;
        }

        public async Task<Produto> UpdateProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
    }
}