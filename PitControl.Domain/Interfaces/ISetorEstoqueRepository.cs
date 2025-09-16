using PitControl.Domain.Model;

namespace PitControl.Domain.Interfaces
{
    public interface ISetorEstoqueRepository
    {
        Task<SetorEstoque> GetById(int id);
        Task<List<SetorEstoque>> GetAll();
        Task<SetorEstoque> AddSetorEstoque(SetorEstoque setorEstoque);
        Task<SetorEstoque> UpdateSetorEstoque(SetorEstoque setorEstoque);
        Task<SetorEstoque> DeleteSetorEstoque(int id);
    }
}