using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PitControl.Application.Common;
using PitControl.Application.Dto;
using PitControl.Application.Interfaces;
using PitControl.Domain.Interfaces;
using PitControl.Domain.Model;

namespace PitControl.Application.Services
{
    public class SetorEstoqueService : ISetorEstoqueService
    {
        private readonly ISetorEstoqueRepository _estoqueRepository;

        public SetorEstoqueService(ISetorEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<Resposta<SetorEstoque>> AddSetorEstoque(SetorEstoqueDto setorEstoqueDto)
        {
            var addEstoque = new SetorEstoque
            (
                setorEstoqueDto.NomeSetor,
                setorEstoqueDto.Corredor,
                setorEstoqueDto.Posicao
            );

            await _estoqueRepository.AddSetorEstoque(addEstoque);
            return new Resposta<SetorEstoque>(addEstoque, "Novo estoque adicionado com sucesso");
        }

        public async Task<Resposta<SetorEstoque>> DeleteSetorEstoque(int id)
        {
            var estoqueId = await _estoqueRepository.GetById(id);
            if (estoqueId == null)
            {
                return new Resposta<SetorEstoque>(null, "Estoque não encontrado", false);
            }
            await _estoqueRepository.DeleteSetorEstoque(id);
            return new Resposta<SetorEstoque>(estoqueId, "Estoque excluido com sucesso");

        }

        public async Task<Resposta<List<SetorEstoque>>> GetAll()
        {
            var estoque = await _estoqueRepository.GetAll();
            return new Resposta<List<SetorEstoque>>(estoque, "Estoque obtido com sucesso");
        }

        public async Task<Resposta<SetorEstoque>> GetById(int id)
        {
            var estoqueId = await _estoqueRepository.GetById(id);
            if (estoqueId == null)
            {
                return new Resposta<SetorEstoque>(null, "Estoque não encontrado", false);
            }

            return new Resposta<SetorEstoque>(estoqueId, "Estoque encontrado com sucesso");
        }

        public async Task<Resposta<SetorEstoque>> UpdateSetorEstoque(SetorEstoqueDto setorEstoqueDto, int id)
        {
            var estoqueId = await _estoqueRepository.GetById(id);
            if (estoqueId == null)
            {
                return new Resposta<SetorEstoque>(null, "Estoque não encontrado", false);
            }

            estoqueId.Update
            (
                setorEstoqueDto.NomeSetor,
                setorEstoqueDto.Corredor,
                setorEstoqueDto.Posicao
            );

            await _estoqueRepository.UpdateSetorEstoque(estoqueId);
            return new Resposta<SetorEstoque>(estoqueId, "Informações de estoque atualizado com sucesso");
        }
    }
}