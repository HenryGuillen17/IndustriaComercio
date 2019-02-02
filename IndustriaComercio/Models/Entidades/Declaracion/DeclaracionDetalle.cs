
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class DeclaracionDetalle 
    {
        public int DeclaracionId { get; set; }
        public int Id { get; set; }
        public int ConceptoId { get; set; }
        public double Valor { get; set; }

        public virtual Concepto Concepto { get; set; }
        public virtual Declaracion Declaracion { get; set; }
    }
}