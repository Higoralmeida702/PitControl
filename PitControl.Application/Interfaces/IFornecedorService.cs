using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PitControl.Application.Common;
using PitControl.Application.Dto;
using PitControl.Domain.Model;

namespace PitControl.Application.Interfaces
{
    public interface IFornecedorService
    {
        Task<Resposta<Fornecedor>> AddFornecedor(FornecedorDto fornecedorDto);
        Task<Resposta<Fornecedor>> UpdateFornecedor(int id, FornecedorDto fornecedorDto);
        Task<Resposta<Fornecedor>> DeleteFornecedor(int id);
        Task<Resposta<Fornecedor>> GetById(int id);
        Task<Resposta<List<Fornecedor>>> GetAll();
    }
}