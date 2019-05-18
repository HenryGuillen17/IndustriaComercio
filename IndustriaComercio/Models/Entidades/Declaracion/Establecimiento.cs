
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class Establecimiento 
    {
        public int EstablecimientoId { get; set; }
        public int ClienteId { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }

        //Propiedades
        public virtual Persona.Cliente Cliente { get; set; }
        public virtual ICollection<EstablecimientoActividad> EstablecimientoActividades { get; set; }
        //public virtual ICollection<Declaracion> Declaraciones { get; set; }
    }
}