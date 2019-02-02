
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class TipoDocumento 
    {
        public int TipoDocumentoId { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Persona.Persona> Personas { get; set; }
    }
}