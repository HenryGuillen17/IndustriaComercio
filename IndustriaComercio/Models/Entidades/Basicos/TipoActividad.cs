
using IndustriaComercio.Models.Entidades.Basicos;
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class TipoActividad
    {
        public int TipoActividadId { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        //Propiedades
        public virtual ICollection<ActividadGravada> ActividadesGravadas { get; set; }
    }
}