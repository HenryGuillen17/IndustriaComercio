
using IndustriaComercio.Models.Entidades.Basicos;
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class TipoSancion 
    {
        public int TipoSancionId { get; set; }
        public string Descripcion { get; set; }
        public double Porcentaje { get; set; }

        public virtual ICollection<DeclaracionPrevia> DeclaracionesPrevias { get; set; }
    }
}