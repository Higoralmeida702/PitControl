using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PitControl.Domain.Interfaces;
using PitControl.Domain.Model;
using PitControl.Infra.Data.Data;

namespace PitControl.Infra.Data.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Fornecedor> AddFornecedor(Fornecedor fornecedor)
        {
            await _context.Fornecedores.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
            return (fornecedor);
        }

        public async Task<Fornecedor> DeleteFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                throw new Exception("Fornecedor não encontrado");
            }

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<List<Fornecedor>> GetAll()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task<Fornecedor> GetById(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                throw new Exception("Fornecedor não encontrado");
            }

            return fornecedor;
        }

        public async Task<Fornecedor> UpdateFornecedor(Fornecedor fornecedor)
        {
            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
            return (fornecedor);
        }
    }
}