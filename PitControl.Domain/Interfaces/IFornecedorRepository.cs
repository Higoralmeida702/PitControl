using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PitControl.Domain.Model;

namespace PitControl.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<Fornecedor> AddFornecedor(Fornecedor fornecedor);
        Task<Fornecedor> UpdateFornecedor(Fornecedor fornecedor);
        Task<Fornecedor> DeleteFornecedor(int id);
        Task<Fornecedor> GetById(int id);
        Task<List<Fornecedor>> GetAll();
    }
}