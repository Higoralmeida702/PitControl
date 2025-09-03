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
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repository;
        private readonly ViaCepService _viaCepService;

        public FornecedorService(IFornecedorRepository repository, ViaCepService viaCepService)
        {
            _repository = repository;
            _viaCepService = viaCepService;
        }

        public async Task<Resposta<Fornecedor>> AddFornecedor(FornecedorDto fornecedorDto)
        {
            if (!string.IsNullOrEmpty(fornecedorDto.Cep) && string.IsNullOrEmpty(fornecedorDto.Logradouro))
            {
                var endereco = await _viaCepService.GetEnderecoByCep(fornecedorDto.Cep);

                fornecedorDto.Logradouro = endereco.Logradouro;
                fornecedorDto.Bairro = endereco.Bairro;
                fornecedorDto.Localidade = endereco.Localidade;
                fornecedorDto.Regiao = endereco.Regiao;
            }
            var fornecedor = new Fornecedor
            (
                fornecedorDto.NomeFornecedor,
                fornecedorDto.Cnpj,
                fornecedorDto.Telefone,
                fornecedorDto.Email,
                fornecedorDto.Cep,
                fornecedorDto.Logradouro,
                fornecedorDto.Bairro,
                fornecedorDto.Localidade,
                fornecedorDto.Regiao
            );

            var resultado = await _repository.AddFornecedor(fornecedor);
            return new Resposta<Fornecedor>(fornecedor, "Novo fornecedor adicionado com sucesso");
        }

        public async Task<Resposta<Fornecedor>> DeleteFornecedor(int id)
        {
            var fornecedor = await _repository.GetById(id);
            if (fornecedor == null)
            {
                return new Resposta<Fornecedor>(null, "Fornecedor não encontrado", false);
            }

            await _repository.DeleteFornecedor(id);
            return new Resposta<Fornecedor>(fornecedor, "Fornecedor deletado com sucesso");

        }

        public async Task<Resposta<List<Fornecedor>>> GetAll()
        {
            var fornecedor = await _repository.GetAll();
            return new Resposta<List<Fornecedor>>(fornecedor, "Fornecedores obtidos com  sucesso");
        }

        public async Task<Resposta<Fornecedor>> GetById(int id)
        {
            var fornecedor = await _repository.GetById(id);
            if (fornecedor == null)
            {
                return new Resposta<Fornecedor>(null, "Fornecedor não encontrado", false);
            }
            return new Resposta<Fornecedor>(fornecedor, "Id de fornecedor obtido com sucesso");
        }

        public async Task<Resposta<Fornecedor>> UpdateFornecedor(int id, FornecedorDto fornecedorDto)
        {
            var fornecedor = await _repository.GetById(id);
            if (fornecedor == null)
            {
                return new Resposta<Fornecedor>(null, "Fornecedor não encontrado", false);
            }

            if (!string.IsNullOrEmpty(fornecedorDto.Cep) && string.IsNullOrEmpty(fornecedorDto.Logradouro))
            {
                var endereco = await _viaCepService.GetEnderecoByCep(fornecedorDto.Cep);

                fornecedorDto.Logradouro = endereco.Logradouro;
                fornecedorDto.Bairro = endereco.Bairro;
                fornecedorDto.Localidade = endereco.Localidade;
                fornecedorDto.Regiao = endereco.Regiao;
            }

            fornecedor.Update
            (
                fornecedorDto.NomeFornecedor,
                fornecedorDto.Cnpj,
                fornecedorDto.Telefone,
                fornecedorDto.Email,
                fornecedorDto.Cep,
                fornecedorDto.Logradouro,
                fornecedorDto.Bairro,
                fornecedorDto.Localidade,
                fornecedorDto.Regiao
            );
            await _repository.UpdateFornecedor(fornecedor);
            return new Resposta<Fornecedor>(fornecedor, "Fornecedor atualizado com sucesso");
        }
    }
}