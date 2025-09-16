using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PitControl.Application.Common;
using PitControl.Application.Dto;
using PitControl.Domain.Model;

namespace PitControl.Application.Interfaces
{
    public interface ISetorEstoqueService
    {
        Task<Resposta<SetorEstoque>> GetById(int id);
        Task<Resposta<List<SetorEstoque>>> GetAll();
        Task<Resposta<SetorEstoque>> AddSetorEstoque(SetorEstoqueDto setorEstoqueDto);
        Task<Resposta<SetorEstoque>> UpdateSetorEstoque(SetorEstoqueDto setorEstoqueDto, int id);
        Task<Resposta<SetorEstoque>> DeleteSetorEstoque(int id);
    }
}