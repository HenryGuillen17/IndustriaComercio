using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IndustriaComercio.Models.Enum
{
    public enum TipoSancion : byte
    {
        [Display(Name = "Sin Sanción")]
        Vacio,

        [Display(Name = "Extemporaneidad")]
        Extemporaneidad,

        [Display(Name = "Corrección")]
        Correccion,

        [Display(Name = "Inexactitud")]
        Inexactitud,

        [Display(Name = "Otro")]
        Otra
    }
}