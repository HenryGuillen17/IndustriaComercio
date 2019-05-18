
using IndustriaComercio.Models.Entidades.Basicos;
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class EstablecimientoActividad 
    {
        public int EstablecimientoId { get; set; }
        public int ActividadId { get; set; }

        public virtual Establecimiento Establecimiento { get; set; }
        public virtual ActividadGravada Actividad { get; set; }
    }
}