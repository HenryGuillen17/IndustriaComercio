using System.Collections.Generic;

namespace IndustriaComercio.Models.Entidades.Basicos
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Descripcion { get; set; }


        // -- FK
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}