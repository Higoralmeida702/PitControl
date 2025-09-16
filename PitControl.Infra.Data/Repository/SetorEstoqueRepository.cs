using Microsoft.EntityFrameworkCore;
using PitControl.Domain.Interfaces;
using PitControl.Domain.Model;
using PitControl.Infra.Data.Data;

namespace PitControl.Infra.Data.Repository
{
    public class SetorEstoqueRepository : ISetorEstoqueRepository
    {
        private readonly ApplicationDbContext _context;

        public SetorEstoqueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SetorEstoque> AddSetorEstoque(SetorEstoque setorEstoque)
        {
            await _context.SetoresEstoque.AddAsync(setorEstoque);
            await _context.SaveChangesAsync();
            return setorEstoque;
        }

        public async Task<SetorEstoque> DeleteSetorEstoque(int id)
        {
            var setorId = await _context.SetoresEstoque.FindAsync(id);
            if (setorId == null)
            {
                throw new Exception("Setor não encontrado");
            }
            _context.SetoresEstoque.Remove(setorId);
            await _context.SaveChangesAsync();
            return setorId;
        }

        public async Task<List<SetorEstoque>> GetAll()
        {
            return await _context.SetoresEstoque.ToListAsync();
        }

        public async Task<SetorEstoque> GetById(int id)
        {
            var setorId = await _context.SetoresEstoque.FindAsync(id);
            if (setorId == null)
            {
                throw new Exception("Setor não encontrado");
            }
            _context.SetoresEstoque.FindAsync(setorId);
            return setorId;
        }

        public async Task<SetorEstoque> UpdateSetorEstoque(SetorEstoque setorEstoque)
        {
            _context.SetoresEstoque.Update(setorEstoque);
            await _context.SaveChangesAsync();
            return setorEstoque;
        }
    }
}