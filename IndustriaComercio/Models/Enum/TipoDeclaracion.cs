using System.ComponentModel.DataAnnotations;

namespace IndustriaComercio.Models.Enum
{
    public enum TipoDeclaracion : byte
    {
        [Display(Name = "-- Seleccione --")]
        Vacio = 0,

        [Display(Name = "Declaración Inicial")]
        DeclaracionInicial = 1,

        [Display(Name = "Sólo Pago")]
        SoloPago = 2,

        [Display(Name = "Correción")]
        Correcion = 3
    }
}