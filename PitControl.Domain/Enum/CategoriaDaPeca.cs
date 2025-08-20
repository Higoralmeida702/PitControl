using System.ComponentModel.DataAnnotations;

namespace PitControl.Domain.Enum
{
    public enum CategoriaDaPeca
    {
        [Display(Name = "Motor")]
        Motor = 1,

        [Display(Name = "Transmissão")]
        Transmissao = 2,

        [Display(Name = "Suspensão")]
        Suspensao = 3,

        [Display(Name = "Freios")]
        Freios = 4,

        [Display(Name = "Eletrica e Eletronica")]
        EletricaEletronica = 5,

        [Display(Name = "Escapemento")]
        Escapamento = 6,

        [Display(Name = "Iluminação")]
        Iluminacao = 7,

        [Display(Name = "Carroceria")]
        Carroceria = 8,

        [Display(Name = "Interior")]
        Interior = 9,

        [Display(Name = "Rodas e Pneu")]
        RodasPneus = 10,

        [Display(Name = "Lubrificação e Filtro ")]
        FiltrosLubrificacao = 11,
    }
}