using IndustriaComercio.Entidades.Basicos;
using System.Collections.Generic;

namespace IndustriaComercio.Models.Entidades.Basicos
{
    public class ActividadGravada
    {
        public int ActividadId { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public double Tarifa { get; set; }
        public double Valor { get; set; }
        public int TipoActividadId { get; set; }

        //Propiedades
        public TipoActividad TipoActividad { get; set; }
        public virtual ICollection<ActividadGravablePorDeclaracion> ActividadesGravadas { get; set; }
        public virtual ICollection<EstablecimientoActividad> EstablecimientoActividades { get; set; }
    }
}