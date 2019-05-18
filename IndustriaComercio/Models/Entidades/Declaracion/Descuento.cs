
using System.Collections.Generic;

namespace IndustriaComercio.Entidades.Basicos
{
    
    public class Descuento 
    {
        public short Anio { get; set; }
        public byte Mes { get; set; }
        public double Porcentaje { get; set; }
        public int ConceptoId { get; set; }
    }
}