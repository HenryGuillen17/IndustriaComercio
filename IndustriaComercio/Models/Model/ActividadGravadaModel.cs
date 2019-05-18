using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndustriaComercio.Models.Model
{

    public class ActividadGravadaModel
    {

        public int ActividadId { get; set; }

        [NotMapped]
        public string Descripcion { get; set; }

        public string Codigo { get; set; }

        [Display(
            Name = "Ingresos Gravados",
            Description = "Lorem ipsum"
        )]
        public double IngresosGravados { get; set; }


        [Display(
            Name = "Ingresos Gravados",
            Description = "Lorem ipsum"
        )]
        public double Tarifa { get; set; }

        public double Valor { get; set; }

        [Display(
            Name = "Impuestos Industria Comercio",
            Description = "Lorem ipsum"
        )]
        public double Impuesto => (IngresosGravados * Tarifa) / 1000;


    }
}