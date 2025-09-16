using System.ComponentModel.DataAnnotations;

namespace PitControl.Application.Dto
{
    public class SetorEstoqueDto
    {
        [Required(ErrorMessage = "O nome do setor é obrigatório.")]
        public string NomeSetor { get; set; }
        [Required(ErrorMessage = "O nome do corredor é obrigatório.")]
        public string Corredor { get; set; }
        [Required(ErrorMessage = "O nome da posição é obrigatório.")]
        public string Posicao { get; set; }

    }
}